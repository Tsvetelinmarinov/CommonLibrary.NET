using System;
using System.Runtime.InteropServices;

namespace CommonLibrary.Interoperability
{
    /// <summary>
    ///  Wraps and interacts with Win32 API(such as user32.dll, kernel32.dll, gdi32.dll etc...).
    ///  Holds the P/Invoke logic for compile time switching between managed(High-level C#) and 
    ///  unmanaged(Low-level C or C++) code.
    ///  Provides the base C functionality for some of the methods in the library.
    /// </summary>
    public static class Win32InteropService
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
            => __C_METHOD_printf__(text);

        // Encapsulates safety the call to the unmanaged Win32 API C function scanf.
        internal static int ScanF(string pattern, out string outputParameter)
            => __C_METHOD_scanf__(pattern, out outputParameter);

        #endregion

        #region Win32 API Connection And P/Invoke Logic

        // SYSLIB1054: Use 'LibraryImportAttribute' instead of 'DllImportAttribute'
        // to generate P/Invoke marshalling code at compile time.
#pragma warning disable SYSLIB1054

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
        [DllImport(
            "user32.dll",
            EntryPoint = "MessageBoxW",
            CharSet = CharSet.Unicode,
            SetLastError = true,
            CallingConvention = CallingConvention.Cdecl
        )]

        private static extern int __C_METHOD_MessageBoxW__(
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
        [DllImport(
             "msvcrt.dll",
             EntryPoint = "printf", 
             CharSet = CharSet.Unicode,
             SetLastError = true,
             CallingConvention = CallingConvention.Cdecl
         )]
        private static extern int __C_METHOD_printf__(string text);

        /// <summary>
        ///  Scans the input from the console according to the specified pattern 
        ///  and stores the result in the output parameter.
        /// </summary>
        /// <param name="pattern">
        ///  The format string that specifies how to interpret the input.
        /// </param>
        /// <param name="outputParameter">
        ///  The parameter to store the result.
        /// </param>
        /// <returns>
        ///  The number of characters read.
        /// </returns>
        [DllImport(
            "msvcrt.dll",
            EntryPoint = "scanf",
            CharSet = CharSet.Unicode,
            SetLastError = true,
            CallingConvention = CallingConvention.Cdecl
        )]
        private static extern int __C_METHOD_scanf__(string pattern, out string outputParameter);

#pragma warning restore SYSLIB1054 // Use 'LibraryImportAttribute' instead of 'DllImportAttribute' 
                                  // to generate P/Invoke marshalling code at compile time.
        #endregion
    }
}