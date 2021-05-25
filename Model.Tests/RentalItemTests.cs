using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
namespace Library.Tests
{
    [TestFixture]
    public class RentalItemTests
    {
        [Test, MaxTime(20)]
        public void OrderItemPropInit()
        {
            RentalItem item = new RentalItem(1, 2, 3m);
            Assert.AreEqual(1, item.BookId);
            Assert.AreEqual(2, item.Count);
            Assert.AreEqual(3m, item.RentalPrice);
        }

        [TestCase(0)]
        [TestCase(-3)]
        [TestCase(null), MaxTime(20)]
        public void OrderItemWithOfRangeCount(int itemCount)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new RentalItem(1, itemCount, 42));
        }

        [TestCase(2, 2)]
        [TestCase(555555555, 555555555), MaxTime(20)]
        public void OrderItemWithRightCount(int expectedItemCount, int itemCount)
        {
            Assert.AreEqual(expectedItemCount, new RentalItem(1, itemCount, 42m).Count);
        }

        [Test]
        public void RentalItemNotNull()
        {
            Assert.AreNotEqual(null, new RentalItem(1, 3, 3m));
        }
    }
}
