using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RecentlyUsedList.Logic;

namespace RecentlyUsedList.Tests
{
    [TestFixture]
    public class StringStackTest
    {
        [Test]
        public void ShouldBeEmptyWhenCreated()
        {
            Assert.AreEqual(0, new StringStack().Count);
        }

        [Test]
        [TestCase(new[] { "apple" }, "apple")]
        [TestCase(new[] { "apple", "banana" }, "banana")]
        [TestCase(new[] { "apple", "banana", "orange" }, "orange")]
        public void ShouldReturnMostRecentlyAddedStringAsTopItem(string[] stringsToPush, string expected)
        {
            StringStack stringStack = new StringStack(stringsToPush);                        
           
            Assert.AreEqual(expected, stringStack.Peek());            
        }

        [Test]
        [TestCase(new[] { "apple" }, "apple", 0)]
        [TestCase(new[] { "apple", "banana", "orange" }, "banana", 1)]
        public void ShouldReturnStringAtIndex(string[] stringsToPush, string expected, int index)
        {
            StringStack stringStack = new StringStack(stringsToPush);            

            Assert.AreEqual(expected, stringStack[index]);
        }

        [Test]
        [TestCase(new[] { "apple", "orange", "apple" }, "apple", 2)]
        public void ShouldMoveDuplicateItemToTopOfList(string[] stringsToPush, string expectedString, int expectedCount)
        {
            StringStack stringStack = new StringStack(stringsToPush);                   

            Assert.AreEqual(expectedString, stringStack.Peek());
            Assert.AreEqual(expectedCount, stringStack.Count);
        }

        [Test]
        public void ShouldNotAddEmptyStrings()
        {
            StringStack stringStack = new StringStack();

            stringStack.Push("");

            Assert.AreEqual(0, stringStack.Count);
        }

        [Test]
        public void ShouldRemoveOldestStringWhenAtCapacityAndNewStringIsAdded()
        {
            StringStack stringStack = new StringStack(3);

            stringStack.Push("apple");
            stringStack.Push("orange");
            stringStack.Push("pineapple");
            stringStack.Push("pear");

            Assert.AreEqual(3, stringStack.Count);
            Assert.AreEqual("pear", stringStack.Peek());
        }
    }
}
