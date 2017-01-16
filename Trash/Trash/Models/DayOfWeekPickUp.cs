using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Trash.Models
{
    public class DayOfWeekPickUp
    {
        public int Id { get; set; }

        public string DayOfWeek { get; set; }
    }
}