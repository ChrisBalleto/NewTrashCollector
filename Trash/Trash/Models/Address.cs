using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Trash.Models
{
    public class Address
    {
        public int Id { get; set; }

        public string StreetOne { get; set; }

        public string StreetTwo { get; set; }

        public string StreetThree { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int ZipCode { get; set; }
    }
}