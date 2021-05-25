using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace Library.Tests
{

    public class BookServiceTests
    {
        BookService bookService;

        [SetUp]
        public void Setup()
        {
            bookService = new BookService(new BookRepositoryMock());
        }

        [TestCase(3, "#")]
        [TestCase(3, "Book")]
        [TestCase(2, "f")]
        [TestCase(1, "#2")]
        [TestCase(0, "4242"), MaxTime(20)]
        public void GetAllByTitle(int expectedResultLength, string query)
        {
            Assert.AreEqual(expectedResultLength, bookService.GetAllByQuery(query).Length);

        }
        [TestCase(1, "Genre1")]
        [TestCase(1, "Genre2")]
        [TestCase(1, "Tech")]
        [TestCase(0, "Genre"), MaxTime(20)]
        public void GetAllByGenre(int expectedResultLength, string query)
        {
            Assert.AreEqual(expectedResultLength, bookService.GetAllByQuery(query).Length);

        }
        [TestCase(1, "Mark")]
        [TestCase(1, "Kass")]
        [TestCase(1, "Martin Fol")]
        [TestCase(0, "Sanin"), MaxTime(20)]
        public void GetAllByAuthor(int expectedResultLength, string query)
        {
            Assert.AreEqual(expectedResultLength, bookService.GetAllByQuery(query).Length);

        }


    }
}