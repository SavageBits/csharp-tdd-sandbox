using System;
using System.Collections.Generic;
using EvenFibonacciNumbers.Logic;
using NUnit.Framework;


namespace EvenFibonacciNumbers.Tests
{
    [TestFixture]
    public class EvenFibSequenceSummerTest
    {

        [Test]
        public void ShouldGenerateAFibonacciSequenceForGivenMaximum()
        {
            Assert.AreEqual(new List<int>{ 1, 2, 3, 5, 8, 13 }, new EvenFibSequenceSummer().GetFibonacciSequence(14));
        }

        //1, 2, 3, 5, 8, 13, 21, 34, 55, 89 - 100
        //2 + 8 + 34 = 44
        [Test]
        public void ShouldSumEvenNumbersForGivenFibonacciSequence()
        {
            Assert.AreEqual(44, new EvenFibSequenceSummer().GetEvenFibSequenceSum(100));
        }
    }
}
