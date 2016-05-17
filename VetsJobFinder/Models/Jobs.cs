using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VetsJobFinder.Models
{
    public class Job
    {
        public int Id { get; set; }
        [DisplayName("Posted On")]
        public DateTime PostedOn { get; set; } = DateTime.Now;
        public string Title { get; set; }
        public string Description { get; set; }
        public SiteUser Employer { get; set; }

        [DisplayName("Start Date")]
        public DateTime StartApplicationDate { get; set; }
        [DisplayName("End Date")]
        public DateTime EndApplicationDate { get; set; }

        public virtual ICollection<ApplyJob> JobsAppliedFor { get; set; } = new List<ApplyJob>();

        
    }
}