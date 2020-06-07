using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using TRbooks.Models;
using TRbooks.ViewModels;

namespace TRbooks.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        ApplicationDbContext context;
        public BooksController() 
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
        public ActionResult Index()
        {
            var books = context.Books.Include(c => c.BookGenre).ToList();
            if (User.IsInRole(RoleName.CanManageBooks))
            {
                return View("List",books);
            }
            return View("ReadOnlyList", books);


        }

        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult Details(int id)
        {
            var book = context.Books.Include(c => c.BookGenre).SingleOrDefault(c => c.Id == id);

            if (book == null)
                return HttpNotFound();
            return View(book);
        }

        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult New()
        {
            var BookGenres = context.BookGenres.ToList();
            var viewModel = new BookFormViewModel()
            {
                BookGenres = BookGenres
            };

            // very bad practice
            viewModel.AddedDate = DateTime.Today;
            // very bad practice
            
            return View("BookForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageBooks)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Book book)
        {
            if (!ModelState.IsValid) 
            {
                var viewModel = new BookFormViewModel(book)
                {
                    BookGenres = context.BookGenres.ToList()
                };
                return View("BookForm",viewModel);
            }

            if (book.Id == 0)
                context.Books.Add(book);
            else
            {
                var bookInDB = context.Books.Single(c => c.Id == book.Id);
                bookInDB.Name = book.Name;
                bookInDB.ReleaseDate = book.ReleaseDate;
                bookInDB.BookGenreId = book.BookGenreId;
                bookInDB.NumberInStock = book.NumberInStock;
                bookInDB.AddedDate = book.AddedDate;
            }

            context.SaveChanges();
            return RedirectToAction("Index", "Books");
        }

        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult Edit(int id)
        {
            var book = context.Books.SingleOrDefault(c => id == c.Id);
            if (book == null)
                return HttpNotFound();
            var viewModel = new BookFormViewModel(book)
            {
                BookGenres = context.BookGenres.ToList()
            };

            return View("BookForm", viewModel);
        }

    
    }
} 