using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CommonLibrary.NET.GUI
{
    /// <summary>
    ///  Provides method for opening a dialog window.
    /// </summary>
    public static class MessageWindow
    {
        // Constants for the cases when no message or question is specified by the endpoint user.
        private static readonly string s_NoMessageText  = "No message has been specified!";
        private static readonly string s_NoQuestionText = "No question has been specified!";

        // Default name of the window, if the same is not specified.
        private static readonly string s_DefaultWindowTitle = "Message Window";


        /// <summary>
        ///  Shows message in a classical Windows dialog window.
        /// </summary>
        /// <param name="message">The message to be shown</param>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        public static void ShowMessage(string message)
        {
            message ??= s_NoMessageText;

            _ = __C__Method__MessageBoxW__(
                IntPtr.Zero, // Not needed.
                message,
                s_DefaultWindowTitle,
                (uint) MessageWindowType.WithButtonOK
            );
        }

        /// <summary>
        ///  Shows a message and waits for the response.
        /// </summary>
        /// <param name="question">The message to be shown</param>
        /// <returns>
        ///  <see cref="MessageWindowResult"/> with the result from the window.
        /// </returns>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        public static MessageWindowResult AskQuestion(string question)
        {
            question ??= s_NoQuestionText;

            return (MessageWindowResult) __C__Method__MessageBoxW__(
                IntPtr.Zero,
                question,
                s_DefaultWindowTitle,
                (uint)(MessageWindowType.WithButtonsYesNo | MessageWindowType.WithQuestionMark)
            );
        }

        /// <summary>
        ///  Shows window with message and title, and waits for the response.
        /// </summary>
        /// <param name="message">The message to be shown</param>
        /// <param name="title">The title of the window</param>
        /// <returns>
        ///  <see cref="MessageWindowResult"/> with the result from the window.
        /// </returns>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        public static MessageWindowResult Show(
            string message,
            string? title = null, 
            MessageWindowType? windowType = null
        ){
            message ??= s_NoMessageText;
            title ??= s_DefaultWindowTitle;
            windowType ??= MessageWindowType.WithButtonOKAndInfoIcon; // Default is button OK and Information icon.

            return (MessageWindowResult)__C__Method__MessageBoxW__(
                IntPtr.Zero,
                message,
                title,
                (uint)windowType
            );
        }


        // C function MessageBoxW() from user32.dll C library.
        // Shows dialog window with message, caption and button/buttons.
#pragma warning disable SYSLIB1054 // Use Library Import with .NET 8 +
        [DllImport(
            "user32.dll", 
            EntryPoint = "MessageBoxW", 
            CharSet = CharSet.Unicode /*Unicode = C wchat_t*/
        )]
        private static extern int __C__Method__MessageBoxW__(IntPtr hWind, string text, string caption, uint windowType);
#pragma warning restore SYSLIB1054
    }
}