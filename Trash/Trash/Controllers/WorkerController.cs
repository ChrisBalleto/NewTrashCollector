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
            var workers = _context.Workers.Include(m => m.ZipcodeTerritory).ToList();
            return View(workers);
        }
        public ActionResult Route(int id)
        {
            var customerZipList = _context.Customers.Include(m => m.Zipcode).ToList();
            
            var temporaryCustomerList2 = new List<Customer>();



            foreach (var customer in customerZipList)
            {
                if (customer.ZipcodeId == id)
                {
                    temporaryCustomerList2.Add(customer);
                }
            }

            return View(temporaryCustomerList2);
        }
        public ActionResult Territory(Worker model)
        {
            var customerZipList = new List<Customer>();
            customerZipList = _context.Customers.Include(m => m.Zipcode).Include(c => c.City).Include(s => s.State).ToList();

            var customers = customerZipList;
            var customerz = new List<Customer>();
            foreach (var customer in customers)
            {
                if (customer.ZipcodeId == model.Id)
                {
                    customerz.Add(customer);
                }
            }
            customers = customerZipList;

            Worker temporaryWorker = new Worker();
            temporaryWorker.CustomerList = customers;
          
            var viewModel = new RouteViewModel
            {

                Customers = customers,
                WorkerZipId = model.Id
            };


            //customer.ConcatAddress = customer.Address.StreetOne + " " + customer.Address.StreetTwo + " " + customer.Address.City.CityName + "," + customer.Address.State.StateName + " " + customer.Address.Zipcode.ZipcodeNum;
            return View("Territory", viewModel);
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
        public ActionResult Edit(int id)
        {
            var worker = _context.Workers.SingleOrDefault(c => c.Id == id);

            if (worker == null)
                return HttpNotFound();
            var viewModel = new WorkerFormViewModel
            {
                Worker = worker,
                ZipCodes = _context.Zipcodes
            };
            return View("WorkerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Worker worker)
        {
            //if (!ModelState.IsValid)
            //{
            //    var viewModel = new WorkerFormViewModel
            //    {
            //        Worker = worker,
            //        ZipCodes = _context.Zipcodes.ToList(),                                   
            //    };

            //    return View("WorkerForm", viewModel);
            //}

            if (worker.Id == 0)
                _context.Workers.Add(worker);
            else
            {
                var workerInDb = _context.Workers.Include(m => m.ZipcodeTerritory).Single(c => c.Id == worker.Id);

                /*TryUpdateModel(workerInDb); */  //Malicious users can mess-up database
                workerInDb.FirstName = worker.FirstName;
                workerInDb.LastName = worker.LastName;
                //customerInDb.Address = customer.Address;
                //customerInDb.Address.City = customer.Address.City;
                workerInDb.ZipcodeTerritoryId = worker.ZipcodeTerritoryId;
                //customerInDb.Address.StateId = customer.Address.StateId;
                //customerInDb.DayOfWeekPickUpId = customer.DayOfWeekPickUpId;
                //customerInDb.MembershipTypeId = customer.MembershipTypeId;
                //customerInDb.IsCurrentCustomer = customer.IsCurrentCustomer;
                //customerInDb.StartDate = customer.StartDate;
                //customerInDb.EMailAddress = customer.EMailAddress;
                //Or use AutoMapper
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Worker");
        }
    }
}