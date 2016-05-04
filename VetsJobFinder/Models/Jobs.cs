using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetsJobFinder.Models
{
    public class Job
    {
        public int Id { get; set; }
        public DateTime PostedOn { get; set; } = DateTime.Now;
        public string Title { get; set; }
        public string Description { get; set; }
        public SiteUser Employer { get; set; }


        public DateTime StartApplicationDate { get; set; }
        public DateTime EndApplicationDate { get; set; }

        public virtual ICollection<ApplyJob> JobsAppliedFor { get; set; } = new List<ApplyJob>();

        
    }
}