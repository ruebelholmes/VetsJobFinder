using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VetsJobFinder.Models
{
    public class Employer
    {
        public int EmployerId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string EmployerEmail { get; set; }
    }
}