using CommonLibrary.NET.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace CommonLibrary.BinaryManager
{
    /// <summary>
    ///  Provides set of static methods for manipulating(Creating, editing, opening ...) a binary file.
    /// </summary>
    public static class Binary
    {
        /// <summary>
        ///  Loads the content of a binary file as list of bytes.
        /// </summary>
        /// <param name="binaryLocation">
        ///  The location of the binary file.
        /// </param>
        /// <returns>
        ///  List of bytes - the content of the binary file.
        /// </returns>
        /// <exception cref="FileException">
        ///  Thrown if the binary file does not exist, or his location is invalid.
        /// </exception>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        public static List<byte> LoadBinary(string binaryLocation)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(binaryLocation, nameof(binaryLocation));

            if (Path.IsPathFullyQualified(binaryLocation) is false)
            {
                throw new FileException($"The binary file path: {binaryLocation} is invalid!");
            }

            if (File.Exists(binaryLocation) is false)
            {
                throw new FileException($"The binary file at: {binaryLocation} does not exist!");
            }

            // The result list of byte - the context of the binary file.
            List<byte> result =[];

            // The input buffer.
            byte[] buffer = new byte[666];

            // The file stream that will read the context of the binary at pieces(buffers).
            // Each piece(buffer) is 666 bytes long.
            using FileStream binaryStream = new(
                binaryLocation,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read,
                buffer.Length
            );

            // This endless loop with read the binary file at pieces.
            while (true)
            {
                // Read 666(or less or 0) bytes, and add him to the result.
                int readedBytes = binaryStream.Read(buffer, 0, buffer.Length);
                result.AddRange(buffer);

                // If the readed bytes are 0, that`s mean the FileStream.Read() method has 
                // reached the end of the stream, so we should break the endless loop now.
                if (readedBytes is 0)
                {
                    break;
                }
            }

            result.TrimExcess();
            return result;
        }

        /// <summary>
        ///  Creates binary file(*.bin) with the bytes of the given text(code, file content etc...).
        /// </summary>
        /// <param name="text">
        ///  The text
        /// </param>
        /// <param name="binaryExportLocation">
        ///  The directory that the created binary file will be exported.
        ///  Only the directory name should be specified, without the file name and his extension.
        ///  The file name and extension are created by the method.
        /// </param>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        public static void CreateBinaryFormText(string text, string binaryExportLocation)
        {
            ArgumentException.ThrowIfNullOrEmpty(text, nameof(text));
            ArgumentException.ThrowIfNullOrWhiteSpace(binaryExportLocation, nameof(binaryExportLocation));

            if (Path.IsPathFullyQualified(binaryExportLocation) is false || Directory.Exists(binaryExportLocation) is false)
            {
                throw new FileException($"The binary location: {binaryExportLocation} is invalid!");
            }

            string fileName = "NewBinaryFile.bin"; // The new file name

            // Get the bytes from the specified text context.
            List<byte> textBytes = [..Encoding.UTF8.GetBytes(text)];

            // File stream that will create the binary file.
            using FileStream binaryFile = new(
                Path.Combine(binaryExportLocation, fileName),
                FileMode.OpenOrCreate,
                FileAccess.Write,
                FileShare.Write
            );

            // Write the bytes to the new binary file at pieces(buffers).
            binaryFile.Write([..textBytes], 0, textBytes.Count);
            
            // I know that the Using directive calls the Close() command
            // witch calls the Flush() command automatically, but I need to be sure...
            binaryFile.Flush();
        }

        /// <summary>
        ///  Prints the bits of a binary file(.exe or .dll or .sys etc...) and returns
        ///  how exactly bytes has been printed.
        /// </summary>
        /// <param name="filePath">
        ///  The directory of the binary file.
        /// </param>
        /// <returns>
        ///  The number of the printed bytes.
        /// </returns>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        public static int PrintContentAndGetBytesCount(string filePath)
        {     
            FileException.ThrowIfFilePathIsNull(filePath); // Checks the file path for NULL and throw and FileException if true.   
            FileException.ThrowIfFileDoesNotExists(filePath); // Checks if the file exists and throw and FileException if not.

            // I Use FileStream here because if i read the file in byte array, if the file is
            // too large that will fill all the memory.
            using FileStream binaryFile = File.OpenRead(filePath!);

            System.Console.ForegroundColor = ConsoleColor.Green; // Green binary code.
            int byteCounter = 0; // Total bytes.

            // Reads the file byte-by-byte.
            // Converts each readed byte to 8 bit binary string(for example 00001001) and prints it.
            while (true) 
            {
                // Each readed byte from the file will be stored here as 32 bit integer.
                int readedByte = binaryFile.ReadByte();

                if (readedByte is -1) //=> ReadByte() return -1 if the end of the file has been reached.
                {
                    break;
                }

                byteCounter++; // Incrementing the counter.

                string binaryString = Convert
                    .ToString(readedByte, 2)  // Converts the bit(as int) to binary string.
                    .PadLeft(8, '0'); // If the binary string is shorter that 8 bits,
                                                         // add the missing bits(0 always) to the left side.

                Console.Write($"{binaryString} " /* Each 8 bit binary string + white space */);
            }
                
            Console.WriteLine();   // New line for indentation after the binary code end.
            Console.ResetColor(); // Resetting the console foreground color to white.
                                 // Currently is green.

            return byteCounter;
        }

        /// <summary>
        ///  Gets the count of the bytes of the file.
        /// </summary>
        /// <param name="filePath">
        ///  The path to the file.
        /// </param>
        /// <returns>
        ///  The count of the file bytes as <see cref="long"/>.
        /// </returns>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        public static long GetBytesCount(string filePath)
        {
            FileException.ThrowIfFilePathIsNull(filePath);
            FileException.ThrowIfFileDoesNotExists(filePath);
            using Stream file = File.OpenRead(filePath); // Open the binary file.
            return file.Length;
        }
    }
}