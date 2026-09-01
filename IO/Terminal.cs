namespace CommonLibrary.IO
{
    using CommonLibrary.Interoperability;

    /// <summary>
    ///  Provides low-level console input/output functionality.
    /// </summary>
    public class Terminal
    {
        // Next constants are used to define the data type patterns for
        // the Win32 API functions like scanf() and printf().
        private const string String = "%s";


        /// <summary>
        ///  Prints the text to the console.
        /// </summary>
        /// <param name="text">
        ///  The text to print to the console.
        /// </param>
        /// <returns>
        ///  The number of characters printed to the console.
        /// </returns>
        public static int Print(string text)
        {
            text ??= string.Empty;
            return Win32InteropService.PrintF(text);
        }

        /// <summary>
        ///  Reads the next line of input from the console and returns it as a string.
        /// </summary>
        /// <returns>
        ///  The string read from the console input. 
        ///  If no input is available, an empty string is returned.
        /// </returns>
        public static string GetInput()
        {
            _ = Win32InteropService.ScanF(String, out string result);
            result ??= string.Empty;
            return result;
        }
    }
}