using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Lexicon_LMS.DataAccessLayer
{
    public class allcontext:DbContext
    {
        public allcontext() : base("DefaultConnection")
        {


        }

        public DbSet<Models.Course> Courses { get; set; }
        public DbSet<Models.Role> Roles { get; set; }
        public DbSet<Models.Module> Modules { get; set; }
        public DbSet<Models.Activity> Activities { get; set; }
    }
}