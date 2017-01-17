using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trash.Models;

namespace Trash.ViewModels
{
    public class WorkerFormViewModel
    {
        public Worker Worker { get; set; }
        public IEnumerable<Zipcode> ZipCodes { get; set; }
     
    }
}