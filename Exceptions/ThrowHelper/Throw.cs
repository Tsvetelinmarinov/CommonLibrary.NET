using CommonLibrary.Exceptions;
using CommonLibrary.Exceptions.ErrorMessages;
using System;
using System.IO;

namespace CommonLibrary.Exceptions.ExceptionsThrowHelper
{
    //
    // Provides methods for throwing exceptions in a more efficient way with check first.
    // When creating a data type, this class is used to reduce the size of the data type(class)
    // code with combined checks and throw statements.
    // Each method make a check first, then throws an exception if the check is how is expected.
    //
    // Example:
    // void OpenFile(string filePath)
    // {
    //    if (string.IsNullOrWhiteSpace(filePath))
    //    {
    //        throw new FileException("File path cannot be null or whitespace!");
    //    }
    //     
    //    if (File.Exists(filePath) is false)
    //    {
    //        throw new FileException("The file does not exist at the specified path: " + filePath);
    //    }
    //    
    //    using FileStream file = File.Open(filePath);
    //    ...
    //    ...
    // }
    // 
    // -> That 'if' statements above can be replaced with a single line:
    // Throw.FileException(filePath);
    //
    public static class Throw
    {
        /// <summary>
        ///  Throws a <see cref="FileException"/> if the provided file path is null, empty, contains only whitespace,
        ///  the file does not exist or the file path is invalid.
        /// </summary>
        /// <param name="filePath">
        ///  The file path to check. 
        /// </param>
        public static void FileException(string? filePath)
        {
            // If the file path is null, empty or whitespace or the file at that
            // path does not exist, it will throw an exception.
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new FileException(Errors.FilePathCanNotBeNullOrWhiteSpace);
            }
     
            if (File.Exists(filePath) is false)
            {
                throw new FileException(Errors.FileDoesNotExists);
            }
        }

        /// <summary>
        ///  Throws a <see cref="PlatformNotSupportedException"/> if the current operating system is not Windows.
        /// </summary>
        public static void IfNotWindows()
        {
            if (OperatingSystem.IsWindows() is false)
            {
                throw new PlatformNotSupportedException(Errors.OnlyWindowsSupported);
            }
        }
    }
}