namespace CommonLibraryTests.BinaryManager
{
    using CommonLibraryTests.BinaryManager.MockObjects;
    using static CommonLibrary.NET.BinaryManager.Binary;

    [TestFixture]
    public class BinaryTests
    {
        [Test]
        public void Test_PrintContentPrintsCurrentNumberOfBytesFormTestFile()
        {
            int bytes = PrintContentAndGetBitsCount(Fake.FileLocation);
            int fakeFileLength = File.ReadAllBytes(Fake.FileLocation).Length;

            Assert.ThatAsync(async () => bytes, Is.EqualTo(fakeFileLength));
        }

        [Test]
        public void Test_GetBytesCountReturnsCorrectFileLength()
        {
            long orgFileLength = File.ReadAllBytes(Fake.FileLocation).Length;
            long currFileLength = GetBytesCount(Fake.FileLocation);

            Assert.That(() => currFileLength, Is.EqualTo(orgFileLength));
        }
    }
}
