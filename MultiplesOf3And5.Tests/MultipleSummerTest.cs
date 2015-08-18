using System;
using MultiplesOf3And5.Logic;
using NUnit.Framework;

// https://projecteuler.net/problem=1
// If we list all the natural numbers below 10 that are multiples of 
// 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.

// Find the sum of all the multiples of 3 or 5 below 1000.

namespace MultiplesOf3And5.Tests
{
    [TestFixture]
    public class MultipleSummerTest
    {
        [Test]
        [TestCase(3, 4)]        
        [TestCase(8, 6)] //8 = 3 + 5
        [TestCase(14, 7)] // 3 + 5 + 6 
        [TestCase(23, 10)] //23 = 3 + 5 + 6 + 9
        public void ShouldReturnSumOfMultiplesGivenAValue(int expected, int ceiling)
        {
            MultipleSummer multipleSummer = new MultipleSummer();

            var sum = 0;

            multipleSummer.SumMultiples(ceiling, ref sum);

            Assert.AreEqual(expected, sum);
        }
    }
}
