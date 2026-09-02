namespace CommonLibrary.IO
{
    using CommonLibrary.Interoperability;
    using System.Runtime.Versioning;

    /// <summary>
    ///  Provides low-level console output functionality.
    /// </summary>
    [SupportedOSPlatform("windows")]
    public class Terminal
    {
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
    }
}