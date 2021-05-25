using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using TRbooks.Models;
using TRbooks.Dtos;
using AutoMapper;

namespace TRbooks.Controllers.Api
{
    public class BooksController : ApiController
    {
        ApplicationDbContext context;
        public BooksController()
        {
            context = new ApplicationDbContext();
        }

        //GET /api/books
        public IHttpActionResult GetBooks()
        {
            var books = context.Books
                .Include(m => m.BookGenre)
                .ToList()
                .Select(Mapper.Map<Book, BookDto>);
            return Ok(books);
        }

        //GET /api/books/1
        public IHttpActionResult GetBook(int id)
        {
            var book = context.Books.SingleOrDefault(c => c.Id == id);
            if (book == null)
                NotFound();

            return Ok(Mapper.Map<Book, BookDto>(book));
        }

        //Post /api/books
        [Authorize(Roles = RoleName.CanManageBooks)]
        [HttpPost]
        public IHttpActionResult CreateBook(BookDto bookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var book = Mapper.Map<BookDto, Book>(bookDto);

            context.Books.Add(book);
            context.SaveChanges();

            bookDto.Id = book.Id;

            return Created(new Uri(Request.RequestUri + "/" + book.Id), bookDto);
        }

        //Put /api/books/1
        [Authorize(Roles = RoleName.CanManageBooks)]
        [HttpPut]
        public IHttpActionResult UpdateBook(int id, BookDto bookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var bookInDb = context.Books.SingleOrDefault(c => c.Id == id);
            if (bookInDb == null)
                return NotFound();

            Mapper.Map(bookDto, bookInDb);

            context.SaveChanges();

            return Ok();
        }
        //DELETE /api/books/1
        [Authorize(Roles = RoleName.CanManageBooks)]
        [HttpDelete]
        public IHttpActionResult RemoveBook(int id)
        {
            var bookInDb = context.Books.SingleOrDefault(c => c.Id == id);
            if (bookInDb == null)
                return NotFound();

            context.Books.Remove(bookInDb);
            context.SaveChanges();

            return Ok();
        }
    }
}
