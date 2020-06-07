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
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext context;
        public NewRentalsController()
        {
            context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult CreateRentals(NewRentalDto newRentalDto) 
        {
            var customer = context.Customers.Single
                (c => c.Id == newRentalDto.CustomerId);
            
            var books = context.Books.Where
                (b => newRentalDto.BookIds.Contains(b.Id)).ToList();

            foreach (var book in books) 
            {
                if (book.NumberAvailable == 0) 
                {
                    return BadRequest("Book is not available.");
                }
                book.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Book = book,
                    DateRented = DateTime.Now
                };

                context.Rentals.Add(rental);
            }
            context.SaveChanges();

            return Ok();
        }
    }
}