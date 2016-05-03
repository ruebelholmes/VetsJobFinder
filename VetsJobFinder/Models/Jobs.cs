using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetsJobFinder.Models
{
    public class Jobs
    {
        public Jobs Id { get; set; }
        public DateTime PostedOn { get; set; } = DateTime.Now;
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string JobEmployer { get; set; }

        
    }
}