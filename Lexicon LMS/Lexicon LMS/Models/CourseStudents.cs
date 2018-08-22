using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lexicon_LMS.Models
{
    public class CourseStudents
    {
        public string Id { get; set; }
        public string Email { get; set; }
        List<ApplicationUser> student = new List<ApplicationUser>();
    }
}