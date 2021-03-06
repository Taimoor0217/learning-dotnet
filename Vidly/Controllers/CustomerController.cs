﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity; //this is very importatnt to add, if you want to use Include for eager loading
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly1.Models;
using Vidly1.Models.ViewModels;
using Vidly.Models.ViewModels;
using Microsoft.Ajax.Utilities;
using System.Net;

namespace Vidly1.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context; //declare a Db context variable


        public CustomerController()
        {
            _context = new ApplicationDbContext(); //Initialize the DB context to use in our controller
        }


        //_context is a disposible object and hence we need to override the default dispose methond to properly dispose.
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        public ActionResult Index()
        {
            var customers = GetCustomers();
           
            var viewModel = new CustomerModel
            {
                Customers = (List<Customer>) customers
            };
            //return Content(customers[0].Name);
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var customers = GetCustomers();
            foreach (var cust in customers)
            {
                if(cust.Id == id)
                {
                    return View(cust);
                }
            }
            return HttpNotFound();
            /*var viewModel = new CustomerModel
            {
                Customers = customers
            };
            //return Content(customers[0].Name);
            return View(viewModel);*/
        }
        //IEnumerable type lets you an itereable object, containing any type of objects.
        private IEnumerable<Customer> GetCustomers()
        {
            /*hardcoded customers*/
            /* return new List<Customer>
              {
                  new Customer { Name = "Dolan Tramp" , Id = 1},
                  new Customer { Name = "Norendar Mudi", Id = 2 },
                  new Customer { Name = "Imrun Kaahn" , Id = 3}
              };*/

            return _context.Customers.Include(c => c.MembershipType ).ToList(); //works like a charm
        }

        
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm" , viewModel);
        }

        [HttpPost] //This ensures that this method can only be accessed by an httppost call
        public ActionResult Save(Customer customer) //COOL !  The model will automatically bind the request data to this model object, this is called model binding
        {

            if(customer.Id == 0) //if this is a new customer
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                
            }
            _context.SaveChanges();

            return RedirectToAction("Index" , "Customer");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,

                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm" , viewModel);
        }

    }
}