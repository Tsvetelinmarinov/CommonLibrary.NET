using CommonLibrary.Exceptions.ExceptionsThrowHelper;
using CommonLibrary.GUI;
using CommonLibrary.Interoperability;
using System;
using System.Runtime.Versioning;

namespace CommonLibrary.NET.GUI
{
    /// <summary>
    ///  Functional Interface IWin32DialogWindow provides methods for 
    ///  opening a classical Windows dialog window.
    ///  NOTE THAT: This interface is platform dependent and only works on Windows OS and
    ///  provides implementation for the static methods inside.
    /// </summary>
    [SupportedOSPlatform("windows")]
    internal interface IWin32DialogWindow
    {
        /// <summary>
        ///  Shows message in a classical Windows dialog window.
        /// </summary>
        /// <param name="message">The message to be shown</param>
        [SupportedOSPlatform("windows")]
        static void ShowMessage(string message)
        {
            Throw.IfNotWindows(); //=> Platform depended data type(MessageWindow)! Only Windows OS is supported.
            message ??= "No message has been provided!";
            
            if (OperatingSystem.IsWindows())
            {
                _ = Win32InteropService.MessageBoxW(
                    IntPtr.Zero, // null pointer, so the dialog will be attached to the current window.
                    message,
                    "Message Window",
                    (uint)MessageWindowType.WithButtonOK
                );
            }
        }

        /// <summary>
        ///  Shows a message and waits for the response.
        /// </summary>
        /// <param name="questionMessage">The message to be shown</param>
        /// <returns>
        ///  <see cref="MessageWindowResult"/> with the result from the window.
        /// </returns>
        [SupportedOSPlatform("windows")]
        static MessageWindowResult AskQuestion(string questionMessage)
        {
            Throw.IfNotWindows();
            questionMessage ??= "No question has been provided!";

            if (OperatingSystem.IsWindows())
            {
                return (MessageWindowResult)Win32InteropService.MessageBoxW(
                    IntPtr.Zero,
                    questionMessage,
                    "Message Window",
                    (uint)MessageWindowType.WithButtonsYesNoAndQuestionMark
                );
            }
            else
            {
                return MessageWindowResult.ResultIgnore; //=> Default is Ignore.
            }
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
        [SupportedOSPlatform("windows")]
        static MessageWindowResult Show(string message, string? title, MessageWindowType? windowType)
        {
            Throw.IfNotWindows(); //=> Platform depended data type(MessageWindow)! Only Windows OS is supported.

            message ??= "No message has been provided!";
            title ??= "Message Window";
            windowType ??= MessageWindowType.WithButtonOKAndInfoIcon; //=> Default is button OK and Information icon.

            if (OperatingSystem.IsWindows())
            {
                return (MessageWindowResult)Win32InteropService.MessageBoxW(
                    IntPtr.Zero,
                    message,
                    title,
                    (uint)windowType
                );
            }
            else
            {
                return MessageWindowResult.ResultIgnore; //=> Default is Ignore.
            }
        }
    }
}