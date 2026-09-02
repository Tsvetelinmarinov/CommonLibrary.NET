namespace CommonLibrary.Exceptions.ErrorMessages
{
    // Provides constants for the library.
    // This class is used to store constant values that are used throughout the library as parameters etc.
    internal static class Errors
    {
        #region CommonLibrary.ExceptionThrower.Throw Constants

        // The default message for the FileException when the file path is null, empty or whitespace.
        internal const string FilePathCanNotBeNullOrWhiteSpace = "File path cannot be null, empty or contain only whitespace!";

        // The default message for the FileException when the file does not exist at the specified path.
        internal const string FileDoesNotExists = "The file does not exist at the specified path.";

        // The default message for the FileException when the file path is not a well-formed URL.
        internal const string FilePathIsNotWellFormedUrl = "The file path is not a well-formed and valid URL!";

        // The default message if the platform is not Windows OS.
        internal const string OnlyWindowsSupported = "This data type is supported only on Windows OS.";

        #endregion
    }
}
