using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace CommonLibrary.Web
{
    /// <summary>
    ///  Provides cross-platform methods for launching the default web browser of the machine.
    /// </summary>
    public static class WebBrowser 
    {
        // The google main page.
        // This is the default page when opening the browser.
        private static readonly Uri s_google = new("https://www.google.com");


        /// <summary>
        ///  Opens the default browser of the machine and navigates to the Google main page.
        /// </summary>
        [MethodImpl(MethodImplOptions.PreserveSig)] 
        public static void Open()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                _ = Process.Start(new ProcessStartInfo
                {
                        FileName = s_google.OriginalString,
                        UseShellExecute = true
                });
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                _ = Process.Start("xdg-open", s_google.OriginalString);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                 _ = Process.Start(new ProcessStartInfo
                 {
                        FileName = "open",
                        Arguments = s_google.OriginalString,
                        UseShellExecute = true
                 });
            }
        }

        /// <summary>
        ///   Opens the default browser of the machine and navigates to the specified URL address.
        ///   If the URL address is invalid the main page of Google will be loaded on start.
        /// </summary>
        /// <param name="url">
        ///  The URL address to navigate to on start.
        /// </param>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        public static void OpenAndNavigate(string? url)
        {
            if (url is null || Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute) is false)
            {
                url = s_google.OriginalString;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                _ = Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                _ = Process.Start("xdg-open", url);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                _ = Process.Start(new ProcessStartInfo
                {
                    FileName = "open",
                    Arguments = url,
                    UseShellExecute = true
                });
            }
        }
    }
}