namespace CommonLibraryTests.BinaryManager;

using NUnit.Framework;
using static CommonLibrary.NET.BinaryManager.BitOperations;

/// <summary>
///  Provides tests of the functionality of BitOperations class.
/// </summary>
[TestFixture]
public class BitOperationsTests
{
    [Test]
    public void Test_InvertAllBitsWorksFine()
    {
        int five = 0b00000101; // The number 5 as binary.
        int invertedFive  = 0b11111010; // Inverted value of 5 for comparing.

        Assert.That(() => invertedFive, Is.EqualTo(InvertAllBits(five)));
    }
}
