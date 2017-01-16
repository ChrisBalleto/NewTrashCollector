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

        public string EmailAddress { get; set; }

        public List<int> WorkerZipCodes { get; set; }
    }
}