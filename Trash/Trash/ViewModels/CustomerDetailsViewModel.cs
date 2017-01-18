using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trash.Models;

namespace Trash.ViewModels
{
    public class CustomerDetailsViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<MembershipType> MembershipTypes{ get; set; }
    }
}