using NumberNames.Logic;
using NUnit.Framework;

namespace NumberNames.Test
{
    [TestFixture]
    public class NumberNameGeneratorTest
    {

        [Test]
        [TestCase("three hundred", 300)]
        [TestCase("three hundred and ten", 310)]
        public void ConvertNumberToString_WithValidNumber_ReturnsName(string expected, int numberToConvert)
        {
            Assert.AreEqual(expected, new NumberNameGenerator().ConvertNumberToString(numberToConvert));
        }

        [Test]
        [TestCase("one", 1)]
        [TestCase("two", 2)]
        [TestCase("three", 3)]
        [TestCase("four", 4)]
        [TestCase("ninety nine", 99)]
        [TestCase("eighty four", 84)]
        //[TestCase("three hundred", 300)]
        public void GetStringNameForNumberLessThanOneHundred_WithValidNumber_ReturnsName(string expected, int numberToConvert)
        {
            Assert.AreEqual(expected, new NumberNameGenerator().GetStringNameForNumberLessThanOneHundred(numberToConvert));
        }

        [Test]
        [TestCase("ninety", 99)]
        [TestCase("eighty", 84)]
        public void GetTensString_WithNumberAboveNineteen_ReturnsStringWithTensPlace(string expected, int numberToConvert)
        {
            Assert.AreEqual(expected, new NumberNameGenerator().GetTensString(numberToConvert));
        }

        [Test]
        [TestCase("three hundred", 300)]
        [TestCase("four hundred", 423)]
        public void GetHundredsString_WithNumberAboveNinetyNine_ReturnsStringWithHundreds(string expected, int numberToConvert)
        {
            Assert.AreEqual(expected, new NumberNameGenerator().GetHundredsString(numberToConvert));
        }
    }
}
