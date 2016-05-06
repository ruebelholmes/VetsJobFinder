using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VetsJobFinder.Models.ViewModels
{
    public class CreateResumeVM
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        
    }
}