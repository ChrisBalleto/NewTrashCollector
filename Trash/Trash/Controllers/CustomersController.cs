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

        public ViewResult Index()
        {

            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

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
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
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
                Address = new Address(),
                MembershipTypes = membershipTypes,
                States = state,
                Cities = city,
                Zipcodes = zipcode,
                DayOfWeekPickUps = dayOfWeekPickUp

            };
            return View("CustomerForm", viewModel);
        }
    }
}