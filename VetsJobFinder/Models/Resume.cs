using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetsJobFinder.Models
{
    public class Resume
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostedOn { get; set; } = DateTime.Now; 
    }
}