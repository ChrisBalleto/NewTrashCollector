using System;
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

        //public ViewResult Index(int id, int zipCodeId)
        //{

        //    var customers = _context.Customers.SingleOrDefault(c => c.Id == id);
        //    //var zipCode = _context.Zipcodes.SingleOrDefault(c => c.Id == zipCodeId)

        //    var viewModel = new CustomerFormViewModel
        //    {
        //        Customer = customers,
        //        //Zipcodes = zipCode

        //    };



        //    return View(viewModel);
        //}

        public ViewResult Index()
        {
            var customers = _context.Customers.Include(m => m.Address.Zipcode).ToList();
            return View(customers);
        }
        public ActionResult Edit(int id, int addressId)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            var address = _context.Addresses.SingleOrDefault(c => c.Id == addressId);

            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                Address = customer.Address,
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
            var customer = _context.Customers.Include(m => m.MembershipType).SingleOrDefault(c => c.Id == id);

            return View(customer);
        }
        //public ActionResult Details(int id)
        //{
        //    var customer = _context.Customers.Include(m => m.Address.Zipcode).Include(c => c.m.SingleOrDefault(c => c.Id == id);
        //    var membershipTypes = _context.MembershipTypes;
        //    var viewModel = new CustomerDetailsViewModel
        //    {
        //        Customer = new Customer(),
        //        MembershipTypes = membershipTypes
        //    };
        //    return View("Details", viewModel);
        //}


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
                Address = new Address(),
                MembershipTypes = membershipTypes,
                States = state,
                Cities = city,
                Zipcodes = zipcode,
                DayOfWeekPickUps = dayOfWeekPickUp

            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    Address = customer.Address,
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
                var customerInDb = _context.Customers.Include(m => m.Address).Single(c => c.Id == customer.Id);

                /*TryUpdateModel(customerInDb); */  //Malicious users can mess-up database
                customerInDb.FirstName = customer.FirstName;
                customerInDb.LastName = customer.LastName;
                customerInDb.Address = customer.Address;
                customerInDb.Address.City = customer.Address.City;
                customerInDb.Address.ZipcodeId = customer.Address.ZipcodeId;
                customerInDb.Address.StateId = customer.Address.StateId;
                customerInDb.DayOfWeekPickUpId = customer.DayOfWeekPickUpId;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsCurrentCustomer = customer.IsCurrentCustomer;
                customerInDb.StartDate = customer.StartDate;
                customerInDb.EMailAddress = customer.EMailAddress;
                //Or use AutoMapper
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

    }
}