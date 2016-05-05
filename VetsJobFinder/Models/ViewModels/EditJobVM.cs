using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VetsJobFinder.Models.ViewModels
{
    public class EditJobVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime AppStart { get; set; }
        [DataType(DataType.Date)]
        public DateTime AppEnd { get; set; }
    }
}