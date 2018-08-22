using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lexicon_LMS.Models
{
    public class Activity
    {
        public int Id { get; set; }

        public string Type { get; set; }
        [Display(Name = "Activity")]
        public string ActivityName { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        public Module Module { get; set; }
        [Display(Name = "Module")]
        public int ModuleId { get; set; }
    }
}