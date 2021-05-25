using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Linq;

namespace Library.Tests
{
    [TestFixture]
    class RentalTests
    {
        List<RentalItem> items;
        Rental standardOrder;

        [SetUp]
        public void Setup()
        {
            items = new List<RentalItem>() { new RentalItem(1,1,10m),
                new RentalItem(2,3,20m),
                new RentalItem(3,1,10m)};
            standardOrder = new Rental(1, items);
        }
        [Test]
        public void OrderWithNullItems()
        {
            Assert.Throws<ArgumentNullException>(() => new Rental(1, null));
        }
        [Test]
        public void OrderTotalRentalPriceWithEmptyItem()
        {
            Assert.AreEqual(0m, new Rental(1, new RentalItem[0]).TotalRentalPrice);
        }
        [Test, MaxTime(20)]
        public void StandardOrderTotalRentalPrice()
        {
            Assert.AreEqual(10m + 20m * 3 + 10m, standardOrder.TotalRentalPrice);
        }
        [Test, MaxTime(20)]
        public void StandardOrderTotalBookCount()
        {
            Assert.AreEqual(1 + 3 + 1, standardOrder.TotalCount);
        }
        [Test, MaxTime(20)]
        public void StandardOrderBookWithSecondIdCount()
        {
            Assert.AreEqual(3, standardOrder.Items.Single(item => item.BookId == 2).Count);
        }
        [Test]
        public void AddNullAsNewBook()
        {
            Assert.Throws<ArgumentNullException>(() => standardOrder.AddItem(null, 33));
        }
        [Test, MaxTime(20)]
        public void AddBookToOrderThatAlreadyInOrder()
        {
            Rental order = standardOrder;
            order.AddItem(new Book(1, "", "", "", "", 10m), 2);
            Assert.AreEqual(5 + 2, order.TotalCount);
            Assert.AreEqual(3, order.Items.Count);
        }
        [Test, MaxTime(20)]
        public void AddNewBookToOrder()
        {
            Rental order = standardOrder;
            order.AddItem(new Book(4, "", "", "", "", 100m), 3);
            Assert.AreEqual(5 + 3, order.TotalCount);
            Assert.AreEqual(3 + 1, order.Items.Count);
            Assert.AreEqual(380m, order.TotalRentalPrice);
        }
        [Test]
        public void RentalNotNull()
        {
            Assert.AreNotEqual(null, standardOrder);
        }
    }
}
