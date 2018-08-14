using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lexicon_LMS.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string ActivityName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        public Module Module { get; set; }  
        public int ModuleId { get; set; }
    }
}