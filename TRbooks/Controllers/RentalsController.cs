using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TRbooks.Models;
using Models;
using TRbooks.Dtos;

namespace TRbooks.Controllers
{
    public class RentalsController : Controller
    {
        ApplicationDbContext context;
        public RentalsController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var rentalList = context.Rentals.ToList();
            return View(rentalList);
        }


        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult New()
        {
            var newRental = new Rental();
            return View(newRental);
        }


        [Authorize(Roles = RoleName.CanManageBooks)]
        [HttpPost]
        public ActionResult CreateRentals(Rental rental)
        {
            if (ModelState.IsValid)
            {
                var viewModel = new Rental
                {
                    Customer = rental.Customer,
                    Book = rental.Book
                };
                return View("New", viewModel);
            }
            if (rental.Id == 0)
            {
                var customer = context.Customers.Single
               (c => c.Name == rental.Customer.Name);

                var book = context.Books.Single
                    (b => b.Name == rental.Book.Name);

                var newRental = new Rental
                {
                    Customer = customer,
                    Book = book,
                    DateRented = DateTime.Now
                };

                context.Rentals.Add(newRental);
            }

            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}