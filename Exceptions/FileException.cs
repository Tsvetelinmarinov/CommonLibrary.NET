using System;
using System.IO;

namespace CommonLibrary.Exceptions
{
    /// <summary>
    ///  Throws when a file does not exist or the file path is invalid.
    /// </summary>
    public class FileException : Exception
    {
        // The exception error message.
        private string? _errorMessage;


//=> CA1822: Mark members as static
//=> Explanation, why i turn off this warning:
//=> ?? Because I do not want to be static. I need it as instance property
//=> so i can use it in the other non-static(instance) properties.
#pragma warning disable CA1822
        // Default error message if the same is not specified.
        private string DefaultErrorMessage
            => "Something went wrong while working with the file/path!";
#pragma warning restore CA1822

        /// <summary>
        ///  Gets or sets the error message of the exception.
        /// </summary>
        private string ErrorMessage
        {
            get => this._errorMessage! /* Can not be null never! */ ;
            set
            {
                // If the specified value is null, then the default error message will be used.
                value ??= this.DefaultErrorMessage;
                this._errorMessage = value;
            }
        }


        /// <summary>
        ///  Creates new instance of the FileException with the
        ///  specified optionally error message and parameter name.
        ///  Both parameters(errorMessage and parameterName) are optional.
        ///  If they are not specified, the default values will be used.
        /// </summary>
        /// <param name="errorMessage">The error message</param>
        /// <param name="parameterName">The name of the parameter that causes the exception</param>
        public FileException(string? errorMessage = null)
        {
            this.ErrorMessage = errorMessage!;
        }


        /// <summary>
        ///  Throws new <see cref="FileException"/> when the file path specified 
        ///  with <paramref name="filePath"/> is null.
        /// </summary>
        /// <param name="filePath">
        ///  The file path.
        /// </param>
        /// <exception cref="FileException">
        ///  Throws when the file path is null.
        /// </exception>
        public static void ThrowIfFilePathIsNull(string? filePath)
        {
            if (filePath is null)
            {
                throw new FileException($"The file path represented with {filePath} is null!");
            }
        }

        /// <summary>
        ///  Throws new FileException when the specified file with
        ///  the parameter <paramref name="filePath"/> does not exists.
        /// </summary>
        /// <param name="filePath">
        ///  The path to the file.
        /// </param>
        public static void ThrowIfFileDoesNotExists(string? filePath)
        {
            if (File.Exists(filePath) is false)
            {
                throw new FileException($"The file specified at {filePath} does not exist!");
            }
        }
    }
}