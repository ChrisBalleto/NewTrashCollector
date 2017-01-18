using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trash.Models;
using System.ComponentModel.DataAnnotations;

namespace Trash.ViewModels
{
    public class RouteViewModel
    {
        
        public IEnumerable<Customer> Customers { get; set; }
        public int WorkerZipId { get; set; }
    }
}