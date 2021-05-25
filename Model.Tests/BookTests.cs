using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Library.Tests
{
    [TestFixture]
    class BookTests
    {
        [Test, MaxTime(20)]
        public void BookCreatesNormaly()
        {
            Book book = new Book(1, "NewBook", "Genre1", "Nikole A.", "OOps", 22m);
            string empty = string.Empty;
            Assert.DoesNotThrow(() => empty = book.Genre);
            Assert.AreEqual("Genre1", empty);
        }

        [TestCase(null)]
        [TestCase("Genre")]
        [TestCase("   ")]
        [TestCase("Tec")]
        [TestCase("Tech4"), MaxTime(20)]
        public void IsGenre_Exist_ReturnFalse(string query)
        {
            Assert.IsFalse(Book.IsGenre(query));

        }
        [TestCase("Genre1")]
        [TestCase("Genre2")]
        [TestCase("Tech"), MaxTime(20)]
        public void IsGenre_Exist_ReturnTrie(string query)
        {
            Assert.IsTrue(Book.IsGenre(query));
        }
    }
}
