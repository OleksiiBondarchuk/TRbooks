using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Library
{
    public class BookService
    {

        readonly IBookRepository bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public Book[] GetAllByQuery(string query)
        {
            if (Book.IsGenre(query))
            {
                return bookRepository.GetAllByGenre(query);
            }
            else
            {
                return bookRepository.GetAllByTitleOrAuthor(query);
            }
        }
    }
}
