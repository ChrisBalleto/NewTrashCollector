﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Trash.Models;
using Trash.ViewModels;

namespace Trash.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customer
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();

        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var customers = _context.Customers.Include(m => m.MembershipType).Include(z => z.City).Include(y => y.State).Include(d =>d.DayOfWeekPickUp).Include(l => l.Zipcode).ToList();
            return View(customers);
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                Cities = _context.Cities,
                Zipcodes = _context.Zipcodes,
                DayOfWeekPickUps = _context.DayOfWeekPickUps,
                States = _context.States,
                MembershipTypes = _context.MembershipTypes
                
            };
            return View("CustomerForm", viewModel);
        }

       
        public ViewResult Details(int id)
        {
            var customer = _context.Customers.Include(m => m.MembershipType).Include(z => z.City).Include(y => y.State)
            .Include(z => z.Zipcode).SingleOrDefault(c => c.Id == id);

            return View(customer);
        }
        public ActionResult AddVacation(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,

            };

            return View("AddVacation", viewModel);
        }

        public ActionResult New()
        {
            var state = _context.States.ToList();
            var city = _context.Cities.ToList();
            var zipcode = _context.Zipcodes.ToList();
            var dayOfWeekPickUp = _context.DayOfWeekPickUps.ToList();
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),

                MembershipTypes = membershipTypes,
                States = state,
                Cities = city,
                Zipcodes = zipcode,
                DayOfWeekPickUps = dayOfWeekPickUp

            };
            return View("CustomerForm", viewModel);
        }
        public ActionResult SaveVacation(Vacation vacation)
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    Cities = _context.Cities.ToList(),
                    Zipcodes = _context.Zipcodes.ToList(),
                    DayOfWeekPickUps = _context.DayOfWeekPickUps.ToList(),
                    States = _context.States.ToList(),
                    MembershipTypes = _context.MembershipTypes.ToList()

                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                /*TryUpdateModel(customerInDb); */  //Malicious users can mess-up database
                customerInDb.FirstName = customer.FirstName;
                customerInDb.LastName = customer.LastName;
                customerInDb.StreetOne = customer.StreetOne;
                customerInDb.StreetTwo = customer.StreetTwo;
                customerInDb.City = customer.City;
                customerInDb.ZipcodeId = customer.ZipcodeId;
                customerInDb.StateId = customer.StateId;
                customerInDb.DayOfWeekPickUpId = customer.DayOfWeekPickUpId;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsCurrentCustomer = customer.IsCurrentCustomer;
                customerInDb.StartDate = customer.StartDate;
                customerInDb.EMailAddress = customer.EMailAddress;
                //Or use AutoMapper
            }
            _context.SaveChanges();
            return RedirectToAction("Details", customer);
        }
        public ActionResult Membership()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}