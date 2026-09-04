namespace CommonLibrary.Tests.BinaryManager
{
    using CommonLibrary.BinaryManager;

    /// <summary>
    ///  Provides test for BitOperations class functionality.
    /// </summary>
    [TestFixture]
    public class BitOperations_Tests
    {
        /// <summary>
        ///  Checks the IsActiveBit() function.
        /// </summary>
        [Test]
        public void Test_IsActiveBitWorksFineWhenTrue()
        {
            int five = 0b00000101;
            bool result = BitOperations.IsActiveBit(five, 0);
            Assert.That(() => result, Is.True);
        }
    }
}
