using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRbooks.Models;
using TRbooks.ViewModels;

namespace TRbooks.Controllers
{
    
    public class CustomersController : Controller
    {
        ApplicationDbContext context;
        public CustomersController() 
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult Details(int id)
        {

            var customer = context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New() 
        {
            var membersipTypes = context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membersipTypes
            };
            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer) 
        {
            if (!ModelState.IsValid) 
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
                context.Customers.Add(customer);
            else 
            {
                var customerInDB = context.Customers.Single(c => c.Id == customer.Id);
                customerInDB.Name = customer.Name;
                customerInDB.Birthdate = customer.Birthdate;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;
                customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;  
            }
            
            context.SaveChanges();

            return RedirectToAction("Index","Customers");
        }
        public ActionResult Edit(int id)
        {
            var customer = context.Customers.SingleOrDefault(c => id  == c.Id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = context.MembershipTypes.ToList()
            };

            return View("CustomerForm",viewModel);
        }
    }
}