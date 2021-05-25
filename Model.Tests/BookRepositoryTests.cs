using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Linq;
namespace Library.Tests
{
    public class BookRepositoryMock : IBookRepository
    {
        public readonly Book[] books =
        {
            new Book(1,"Book #1 foz","Genre1","Mark Adler","Some description",1.3m ),
            new Book(2,"Book #3","Genre2","Martin Foller" ,"Some description",2.3m ),
            new Book(3,"foz Book #2","Tech","Antonio Kass","Some description",3.3m )
        };
        public Book[] GetAllByGenre(string genre)
        {
            return books.Where(book => book.Genre == genre).ToArray();
        }

        public Book[] GetAllByIds(IEnumerable<int> bookIds)
        {
            var foundBooks = from book in books
                             join bookId in bookIds on book.Id equals bookId
                             select book;
            return foundBooks.ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string query)
        {
            return books.Where(book => book.Title.Contains(query) ||
                                        book.Author.Contains(query)).ToArray();
        }
        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);
        }
    }

    [TestFixture]
    class BookRepositoryTests
    {
        BookRepositoryMock repositoryMock;
        [SetUp]
        public void Setup()
        {
            repositoryMock = new BookRepositoryMock();
        }


        [Test, MaxTime(20)]
        public void GetBookByRightId()
        {
            Assert.AreEqual(repositoryMock.GetById(1).Author, "Mark Adler");
        }
        [Test, MaxTime(20)]
        public void GetBookByFalseId()
        {
            Assert.AreNotEqual(repositoryMock.GetById(2).Author, "Mark Adler");
        }
        [Test, MaxTime(20)]
        public void GetBookByOutOfRangeId()
        {
            Assert.Throws<InvalidOperationException>(() => repositoryMock.GetById(5));
        }
        [Test, MaxTime(20)]
        public void GetBooksByCorrectIds()
        {
            var byIds = repositoryMock.GetAllByIds(new List<int>() { 1, 2 });
            Assert.AreEqual(repositoryMock.books.First(book => book.Id == 1), byIds[0]);
            Assert.AreEqual(repositoryMock.books.First(book => book.Id == 2), byIds[1]);
        }
        [Test, MaxTime(20)]
        public void GetBooksByWrongIds()
        {
            var byIds = repositoryMock.GetAllByIds(new List<int>() { 33, 4 });
            Assert.Throws<IndexOutOfRangeException>(() => byIds[0].ToString());
            Assert.Throws<IndexOutOfRangeException>(() => byIds[1].ToString());
        }
    }
}
