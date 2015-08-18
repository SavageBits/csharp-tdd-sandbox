using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;

namespace Reorderer.Tests
{
    [TestFixture]
    public class ReorderingMachineTest
    {
        [Test]
        [TestCase(new int[] { 3, 2 }, 1, 1, 1, new int[] { 2, 3 })]
        [TestCase(new int[] { 1, 3, 2 }, 1, 2, 2, new int[] { 2, 1, 3 })]
        [TestCase(new int[] { 1, 3, 2, 5, 6, 2 }, 3, 3, 0, new int[] { 2, 5, 6, 1, 3, 2 })]
        public void Reorder_WithValidRange_ModifiesSet(int[] arrayToReorder, int beginningOfRange, int sizeOfRange, int target, int[] expected)
        {
            ReorderingMachine reorderingMachine = new ReorderingMachine();

            int[] anyArrayOfPositiveInts = arrayToReorder;

            reorderingMachine.Load(anyArrayOfPositiveInts);

            var actual = reorderingMachine.Reorder(beginningOfRange, sizeOfRange, target);

            Assert.AreEqual(expected, actual);
        }
    }
}
