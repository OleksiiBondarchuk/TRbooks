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
    public class CustomersController : ApiController
    {
        private ApplicationDbContext context;
        public CustomersController()
        {
            context = new ApplicationDbContext();
        }

        //GET /api/customers
        public IHttpActionResult GetCustomers()
        {
            var customers = context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customers);
        }

        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                NotFound();

            return Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }

        //Post /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            context.Customers.Add(customer);
            context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id ), customerDto);
        }

        //Put /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDto,customerInDb);
            
            context.SaveChanges();

            return Ok();
        }
        //Delete /api/customers/1
        [HttpDelete]
        public IHttpActionResult RemoveCustomer(int id)
        {
            var customerInDb = context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();

            context.Customers.Remove(customerInDb);
            context.SaveChanges();

            return Ok();
        }
    }
}
