using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Trash.Models
{
    public class MembershipType
    {
        public int Id { get; set; }

        public string MembershipName { get; set; }

        public double PickUpRate { get; set; }
    }
}