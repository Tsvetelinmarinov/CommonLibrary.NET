namespace CommonLibraryTests.Web
{
    using static CommonLibrary.NET.Web.WebBrowser;

    /// <summary>
    ///  Provides tests of the functionality of the CommonLibrary.NET.Web.WebBrowser
    /// </summary>
    public class WebBrowserTests
    {
        [Test]
        public void Test_OpenCommandDoesNotThrowException()
        {
            Assert.DoesNotThrow(Open);
        }

        [Test]
        public void Test_OpenAndNavigateCommandWorksFineWithLink()
        {
            Assert.DoesNotThrow(() => OpenAndNavigate("https://www.github.com"));
        }
    }
}
