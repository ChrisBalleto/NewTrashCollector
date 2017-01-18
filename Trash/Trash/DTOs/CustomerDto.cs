using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trash.Models;
using System.ComponentModel.DataAnnotations;

namespace Trash.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public int AddressId { get; set; }

        public string EMailAddress { get; set; }

        public bool IsCurrentCustomer { get; set; }

        public int DayOfWeekPickUpId { get; set; }

        public int MembershipTypeId { get; set; }

        public DateTime StartDate { get; set; }

        public string ConcatAddress { get; set; }
    }
}