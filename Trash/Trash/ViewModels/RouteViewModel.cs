using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trash.Models;

namespace Trash.ViewModels
{
    public class RouteViewModel
    {
        public Customer Customer { get; set; }
        public Address Address { get; set; }
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<State> States { get; set; }
        public IEnumerable<Zipcode> Zipcodes { get; set; }
        public int WorkerZip { get; set; }
    }
}