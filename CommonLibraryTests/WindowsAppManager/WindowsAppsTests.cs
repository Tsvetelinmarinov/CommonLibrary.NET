namespace CommonLibraryTests.WindowsAppManager
{
    using CommonLibrary.NET.Exceptions;
    using static CommonLibrary.NET.WindowsAppManager.WindowsApps;

    /// <summary>
    ///  Provides tests for OpenFileManager() function in CommonLibrary.NET.WindowsAppsManager.WindowsApps class.
    /// </summary>
    public class WindowsAppsTests
    {
        [Test]
        public void Test_OpenFileManagerCommandWorksFineWithCorrectURL()
        {
            // Attempt to open the user folder.
            string url = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            Assert.DoesNotThrow(() => OpenFileManager(url));
        }

        [Test]
        public void Test_OpenFileManagerCommandThrowsExceptionWhenInvalidURL()
        {
            string url = "C:///Windows/InvalidPath/Nowhere";
            Assert.Throws<FileException>(() => OpenFileManager(url));
        }
    }
}
