using System;
using System.Collections.Generic;
using NUnit.Framework;
using PrimeFactorer.Logic;


namespace PrimeFactorer.Tests
{
    [TestFixture]
    public class PrimeFactorerTest
    {
        [Test]
        [TestCase(new [] { 1, 2 }, 2)]
        [TestCase(new [] { 1, 2, 4 }, 4)]
        [TestCase(new [] { 1, 3, 5, 15 }, 15)]
        [TestCase(new [] { 1 }, 6008514751)]
        public void ShouldReturnFactors(int[] expected, long number)
        {
            Assert.AreEqual(expected, PrimeFactorDoer.GetFactors(number).ToArray());
        }

        [Test]
        [TestCase(3, true)]
        [TestCase(5, true)]
        [TestCase(29, true)]
        [TestCase(6, false)]
        [TestCase(15, false)]
        [TestCase(14, false)]
        [TestCase(21, false)]
        public void ShouldReturnWhetherNumberIsPrime(int number, bool expected)
        {
            PrimeFactorDoer primeFactorDoer = new PrimeFactorDoer();

            Assert.AreEqual(expected, primeFactorDoer.IsPrime(number));
        }

        [Test]
        [TestCase(new []{ 1, 2, 3 }, 6)]
        [TestCase(new[] { 1, 5, 7, 13, 29 }, 13195)]
        public void ShouldReturnPrimeFactors(int[] expected, int number)
        {
            PrimeFactorDoer primeFactorDoer = new PrimeFactorDoer();

            Assert.AreEqual(expected, primeFactorDoer.GetPrimeFactors(number));
        }

        //[Test]
        ////600851475143
        //public void ShouldReturnHighestPrimeFactor()
        //{
        //    PrimeFactorDoer primeFactorDoer = new PrimeFactorDoer();

        //    Assert.AreEqual(29, primeFactorDoer.GetHighestPrimeFactor(600851475143));
        //}
    }
}
