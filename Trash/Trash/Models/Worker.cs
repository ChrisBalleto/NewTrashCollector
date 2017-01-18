using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Trash.Models
{
    public class Worker
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public Zipcode ZipcodeTerritory { get; set; }

        public int ZipcodeTerritoryId { get; set; }

        public IEnumerable<Customer> CustomerList { get; set; }
    }
}