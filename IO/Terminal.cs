namespace CommonLibrary.IO
{
    using CommonLibrary.Interoperability;

    /// <summary>
    ///  Provides low-level console input/output functionality.
    /// </summary>
    public static class Terminal
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