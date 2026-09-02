using CommonLibrary.Interoperability;
using CommonLibrary.NET.Exceptions.ExceptionsThrowHelper;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace CommonLibrary.GUI
{
    /// <summary>
    ///  Provides method for opening a dialog window.
    /// </summary>
    [SupportedOSPlatform("windows")]
    public class MessageWindow
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
            Throw.IfNotWindows(); //=> Platform depended data type(MessageWindow)! Only Windows OS is supported.
            message ??= s_NoMessageText;

            _ = Win32InteropService.MessageBoxW(
                IntPtr.Zero, // null pointer, so the dialog will be attached to the current window.
                message,
                s_DefaultWindowTitle,
                (uint)MessageWindowType.WithButtonOK
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
            Throw.IfNotWindows();
            question ??= s_NoQuestionText;

            return (MessageWindowResult) Win32InteropService.MessageBoxW(
                IntPtr.Zero,
                question,
                s_DefaultWindowTitle,
                (uint)MessageWindowType.WithButtonsYesNoAndQuestionMark
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
            Throw.IfNotWindows(); //=> Platform depended data type(MessageWindow)! Only Windows OS is supported.

            message ??= s_NoMessageText;
            title ??= s_DefaultWindowTitle;
            windowType ??= MessageWindowType.WithButtonOKAndInfoIcon; //=> Default is button OK and Information icon.

            return (MessageWindowResult)Win32InteropService.MessageBoxW(
                IntPtr.Zero,
                message,
                title,
                (uint)windowType
            );
        }
    }
}