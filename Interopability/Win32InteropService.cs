using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CommonLibrary.Interoperability
{
    /// <summary>
    ///  Wraps and interacts with Win32 API(such as user32.dll, kernel32.dll, gdi32.dll etc...).
    ///  Holds the P/Invoke logic for compile time switching between managed(High-level C#) and 
    ///  unmanaged(Low-level C or C++) code.
    ///  Provides the base C functionality for some of the methods in the library.
    /// </summary>
    internal partial class Win32InteropService
    {
        #region C# Wrapper Methods For Win32 API Functions

        // Encapsulates safety the call to the unmanaged Win32 API C function MessageBoxW.
        internal static int MessageBoxW(IntPtr parentWindowHandle, string message, string title, uint windowType)
        {
            return __C_METHOD_MessageBoxW__(
                parentWindowHandle,
                message,
                title,
                windowType
            );
        }

        // Encapsulates safety the call to the unmanaged Win32 API C function printf.
        internal static int PrintF(string text)
        {
            return __C_METHOD_printf__(text);
        }

        #endregion

        #region Win32 API Connection And P/Invoke Logic

        /// <summary>
        ///  Shows classical Windows dialog window with a message, title, and buttons.
        /// </summary>
        /// <param name="message">
        ///  The message to display.
        /// </param>
        /// <param name="title">
        ///  The title of the dialog window.
        /// </param>
        /// <param name="windowType">
        ///  The type of the dialog window.
        /// </param>
        /// <returns>
        ///  The result of the dialog window.
        /// </returns>
        [LibraryImport(
            "user32.dll",
            EntryPoint = "MessageBoxW",
            StringMarshalling = StringMarshalling.Utf8,
            SetLastError = true
        )]
        [UnmanagedCallConv(CallConvs =[typeof(CallConvCdecl)])]
        private static partial int __C_METHOD_MessageBoxW__(
            IntPtr parentWindowHandle, 
            string message, 
            string title, 
            uint windowType
        );

        /// <summary>
        ///  Prints the text in the console.
        /// </summary>
        /// <param name="text">
        ///  The text to be printed.
        /// </param>
        /// <returns>
        ///  The number of characters printed.
        /// </returns>
        [LibraryImport(
            "msvcrt.dll",
            EntryPoint = "printf", 
            SetLastError = true, 
            StringMarshalling = StringMarshalling.Utf8
        )]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        private static partial int __C_METHOD_printf__(string text);

        #endregion
    }
}