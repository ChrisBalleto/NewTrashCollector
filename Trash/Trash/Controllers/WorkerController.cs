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
    public class WorkerController : Controller
    {
        private ApplicationDbContext _context;
        public WorkerController()
        {
            _context = new ApplicationDbContext();

        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Worker
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult New()
        {
            var zipcode = _context.Zipcodes.ToList();
            var viewModel = new WorkerFormViewModel
            {
                Worker = new Worker(),
                ZipCodes = zipcode,

            };
            return View("WorkerForm", viewModel);
        }
        [HttpPost]
        public ActionResult Save(Worker worker, Zipcode zipcode)
        {
            //if (!ModelState.IsValid)
            //{
            //    var viewModel = new CustomerFormViewModel
            //    {
            //        Customer = customer,
            //        Address = customer.Address,
            //        Cities = _context.Cities.ToList(),
            //        Zipcodes = _context.Zipcodes.ToList(),
            //        DayOfWeekPickUps = _context.DayOfWeekPickUps.ToList(),
            //        States = _context.States.ToList(),
            //        MembershipTypes = _context.MembershipTypes.ToList()

            //    };

            //    return View("CustomerForm", viewModel);
            //}

            if (worker.Id == 0)
                _context.Workers.Add(worker);
            else
            {
                var workerInDb = _context.Customers.Single(c => c.Id == worker.Id);

                TryUpdateModel(workerInDb);   //Malicious users can mess-up database
                //customerInDb.FirstName = customer.FirstName;
                //customerInDb.LastName = customer.LastName;
                //customerInDb.Address = customer.Address;
                //customerInDb.Address.City = customer.Address.City;
                //customerInDb.Address.ZipcodeId = customer.Address.ZipcodeId;
                //customerInDb.Address.StateId = customer.Address.StateId;
                //customerInDb.DayOfWeekPickUpId = customer.DayOfWeekPickUpId;
                //customerInDb.MembershipTypeId = customer.MembershipTypeId;
                //customerInDb.IsCurrentCustomer = customer.IsCurrentCustomer;
                //customerInDb.StartDate = customer.StartDate;
                //customerInDb.EMailAddress = customer.EMailAddress;
                //Or use AutoMapper
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Workers");
        }
    }
}