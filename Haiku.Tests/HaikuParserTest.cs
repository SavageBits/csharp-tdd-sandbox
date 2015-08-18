using System;
using Haiku.Logic;
using NUnit.Framework;

namespace Haiku.Tests
{
    [TestFixture]
    public class HaikuParserTest
    {
        [Test]
        [TestCase("dog", 1)]
        [TestCase("doghead", 2)]
        [TestCase("dogfishhead", 3)]
        [TestCase("code", 2)]
        [TestCase("happy test path", 4)]
        [TestCase("happy test path art", 5)]
        public void CountSyllables_WithValidString_ReturnsCorrectCount(string stringToCount, int expected)
        {
            HaikuParser haikuParser = GetNewHaikuParser();

            Assert.AreEqual(expected, haikuParser.CountSyllables(stringToCount));
        }

        [Test]
        [TestCase("//", 3)]
        [TestCase("some words/another words", 2)]
        [TestCase("some words/another words/what more words?", 3)]
        public void CountLines_WithValidString_ReturnsCorrectCount(string stringToCount, int expected)
        {
            HaikuParser haikuParser = GetNewHaikuParser(stringToCount);

            Assert.AreEqual(expected, haikuParser.CountLines());
        }

        [Test]
        [TestCase('a', true)]
        [TestCase('e', true)]
        [TestCase('b', false)]
        [TestCase('s', false)]
        public void IsVowel_WithValidLetter_CorrectlyReturnsTrueOrFalse(char validLetter, bool expected)
        {            
            var haikuParser = GetNewHaikuParser();

            Assert.AreEqual(expected, haikuParser.IsVowel(validLetter));
        }

        [Test]
        [TestCase("happy purple frog/eating bugs in the marshes/get indigestion", true)]
        [TestCase("computer programs/the bugs try to eat my code/i will not let them", false)]
        [TestCase(null, false)]
        [TestCase("", false)]
        public void IsHaiku_WithValidString_CorrectlyReturnsTrueOrFalse(string haikuToTest, bool expected)
        {
            var haikuParser = GetNewHaikuParser(haikuToTest);

            Assert.AreEqual(expected, haikuParser.IsHaiku());
        }

        public HaikuParser GetNewHaikuParser(string haikuToParse = null)
        {
            const string anyValidString = "test haiku";            

            return haikuToParse != null ? new HaikuParser(haikuToParse) : new HaikuParser(anyValidString);
        }
    }
}
