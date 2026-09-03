using CommonLibrary.GUI;
using System.Runtime.Versioning;

namespace CommonLibrary.NET.GUI
{
    /// <summary>
    ///  Provides a platform dependent data type for opening a classical Windows dialog window.
    /// </summary>
    [SupportedOSPlatform("windows")]
    public sealed class MessageWindow
    {
        /// <summary>
        ///  Shows message in a classical Windows dialog window.
        /// </summary>
        /// <param name="message">The message to be shown</param>
        public static void ShowMessage(string message)
        {
            IWin32DialogWindow.ShowMessage(message);
        }

        /// <summary>
        ///  Shows a message and waits for the response.
        /// </summary>
        /// <param name="questionMessage">The message to be shown</param>
        /// <returns>
        ///  <see cref="MessageWindowResult"/> with the result from the window.
        /// </returns>
        public static MessageWindowResult AskQuestion(string question)
        {
            return IWin32DialogWindow.AskQuestion(question);
        }

        /// <summary>
        ///  Shows window with message and title, and waits for the response.
        /// </summary>
        /// <param name="message">The message to be shown</param>
        /// <param name="title">The title of the window</param>
        /// <param name="windowType">The type of the window</param>
        /// <returns>
        ///  <see cref="MessageWindowResult"/> with the result from the dialog.
        /// </returns>
        public static MessageWindowResult Show(
            string message,
            string title,
            MessageWindowType windowType
        ){
            return IWin32DialogWindow.Show(message, title, windowType);
        }
    }
}
