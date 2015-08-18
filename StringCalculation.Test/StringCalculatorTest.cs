using System;
using System.Security.Authentication.ExtendedProtection;
using NUnit.Framework;
using Telerik.JustMock;

namespace StringCalculation.Test
{
    [TestFixture]
    public class StringCalculatorTest
    {        
        [Test]
        public void Add_WithZeroNumbers_Returns0()
        {
            StringCalculator stringCalculator = GetNewStringCalculator();

            Assert.AreEqual(0, stringCalculator.Add());
        }

        [Test]
        [TestCase("2,8", 10)]
        [TestCase("3,5,18", 26)]
        [TestCase("3,5,18,4", 30)]
        public void Add_WithValidParameters_ReturnsCorrectSum(string stringToCalculate, int expected)
        {
            StringCalculator stringCalculator = GetNewStringCalculator();

            int actual = stringCalculator.Add(stringToCalculate);

            Assert.AreEqual(expected, actual);
        }        

        [Test]
        [TestCase("5", 5)]
        [TestCase("152", 152)]
        public void Add_WithOneNumber_ReturnsThatNumber(string stringToCalculate, int expected)
        {
            StringCalculator stringCalculator = GetNewStringCalculator();

            Assert.AreEqual(expected, stringCalculator.Add(stringToCalculate));
        }                      

        [Test]
        [TestCase("3\n5\n18\n4", 30)]
        public void Add_WithValidParametersSeparatedByNewLines_ReturnsCorrectSum(string stringToCalculate, int expected)
        {
            StringCalculator stringCalculator = GetNewStringCalculator();

            Assert.AreEqual(expected, stringCalculator.Add(stringToCalculate));
        }

        [Test]
        [TestCase("3\n5\n18\n4",30)]
        public void Add_WithValidParametersAndCustomDelimiter_ReturnsCorrectSum(string stringToCalculate, int expected)
        {
            StringCalculator stringCalculator = GetNewStringCalculator();

            Assert.AreEqual(expected, stringCalculator.Add(stringToCalculate));
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void Add_With3AndNegative3_ThrowsException()
        {
            StringCalculator stringCalculator = GetNewStringCalculator();

            stringCalculator.Add("3,-3");
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void Add_WithNegative10And3AndNegative3_ThrowsException()
        {
            StringCalculator stringCalculator = GetNewStringCalculator();

            stringCalculator.Add("-10,3,-3");
        }

        [Test]
        public void Add_With2And1001_Returns2()
        {
            StringCalculator stringCalculator = GetNewStringCalculator();

            Assert.AreEqual(2, stringCalculator.Add("2,1001"));
        }

        [Test]
        [TestCase("//[***]\n1***2***3", 6)]
        [TestCase("//[%%]\n1%%5%%3", 9)]
        public void Add_WithDelimiterLongerThanOneChar_ReturnsCorrectSum(string stringToCalculate, int expected)
        {
            StringCalculator stringCalculator = GetNewStringCalculator();

            Assert.AreEqual(expected, stringCalculator.Add(stringToCalculate));
        }

        [Test]
        [TestCase("//[***][%]\n1***2***3%4", 10)]
        [TestCase("//[***][%][@@]\n1***2***3%4@@5", 15)]
        public void Add_WithMultipleDelimiters_ReturnsCorrectSum(string stringToCalculate, int expected)
        {
            StringCalculator stringCalculator = GetNewStringCalculator();

            Assert.AreEqual(expected, stringCalculator.Add(stringToCalculate));
        }

        [Test]
        public void Add_WithValidParameters_WritesSumToConsole()
        {
            StringCalculator stringCalculator = GetNewStringCalculator();

            stringCalculator.Add("1,2");

            Mock.Assert(() => stringCalculator.StringCalculatorLogger.Write("3"), Occurs.Once());                         
        }

        private StringCalculator GetNewStringCalculator()
        {
            var fakeLogger = Mock.Create<ILogger>();
            StringCalculator stringCalculator = new StringCalculator(fakeLogger);

            return new StringCalculator(fakeLogger);            
        }

        //[Test]
        //public void CloseViewWhenViewIsNotDirty()
        //{
        //    // Create the mock objects
        //    IMock msgBoxMock = new DynamicMock(typeof(IMessageBoxCreator));
        //    IMock viewMock = new DynamicMock(typeof(IView));

        //    // Define the expected interaction
        //    msgBoxMock.ExpectNoCall(“AskYesNoQuestion”, typeof(string), typeof(string));

        //    // Very simply set the screen to be in a “clean” state
        //    viewMock.ExpectAndReturn(“IsDirty”, false);
        //    viewMock.Expect(“Close”);

        //    // Create the presenter class with the mock objects
        //    Presenter presenter = new Presenter(
        //        (IView) viewMock.MockInstance,
        //        (IMessageBoxCreator) msgBoxMock.MockInstance);

        //    // Perform the unit of work
        //    presenter.Close();

        //    // Verify the interaction
        //    _msgBoxMock.Verify();
        //    _viewMock.Verify();
        //}
    }
}
