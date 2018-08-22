using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lexicon_LMS.Models
{
    public class Module
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string ModuleName { get; set; }
        public string Description { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public Course Course { get; set; }
        [Display(Name = "Course")]
        public int CourseId { get; set; }
    }   
}