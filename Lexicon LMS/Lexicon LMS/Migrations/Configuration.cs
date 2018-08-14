namespace Lexicon_LMS.Migrations
{
    using Lexicon_LMS.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Lexicon_LMS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "IdentityDemo.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);

            var userManager = new ApplicationUserManager(userStore);
            var emails = new[] { "john@lexicon.se", "user@lexicon.se", "admin@lexicon.se", "editor@lexicon.se" };

            foreach (var email in emails)
            {




                if (context.Users.Any(u => u.UserName == email)) continue;

                var user = new ApplicationUser { UserName = email, Email = email };
                var result = userManager.Create(user, "foobar");
                if (!result.Succeeded)
                {

                    throw new Exception(string.Join("\n", result.Errors));

                }
            }

            var roleStore = new RoleStore<IdentityRole>(context);

            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var roleNames = new[] { "Student", "Teacher" };

            foreach (var roleName in roleNames)
            {

                if (context.Roles.Any(r => r.Name == roleName)) continue;

                var role = new IdentityRole { Name = roleName };
                var result = roleManager.Create(role);

                if (!result.Succeeded)
                {

                    throw new Exception(string.Join("\n", result.Errors));

                }
                var teacherUser = userManager.FindByName("admin@lexicon.se");
                userManager.AddToRole(teacherUser.Id, "Teacher");

                var studentUser = userManager.FindByName("editor@lexicon.se");
                userManager.AddToRole(studentUser.Id, "Student");

            }
        }
    }
}