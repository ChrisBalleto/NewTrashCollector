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

        public City City { get; set; }

        public string CityId { get; set; }

        public State State { get; set; }

        public string StateId { get; set; }
        
        public Zipcode Zipcode { get; set; }
        
        public int ZipcodeId { get; set; }
    }
}