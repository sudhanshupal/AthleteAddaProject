using AthleteAddaProject.Models;

namespace AthleteAddaProject.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<AthleteAddaProject.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AthleteAddaProject.Models.ApplicationDbContext context)
        {
            this.AddRoles();
            this.AddUsers();
        }

        bool AddRoles()
        {
            bool success = true;
            try
            {
                var store = new RoleStore<IdentityRole>(new ApplicationDbContext());
                var roleManager = new RoleManager<IdentityRole>(store);

                if (!roleManager.RoleExists("SuperAdmin"))
                {
                    var role = new IdentityRole { Name = "SuperAdmin" };
                    roleManager.Create(role);
                }

                if (!roleManager.RoleExists("Publisher"))
                {
                    var role = new IdentityRole { Name = "Publisher" };
                    roleManager.Create(role);
                }
            }
            catch (Exception ex)
            {
                //todo: Exception handling
                success = false;
            }
            return success;
        }

        bool AddUsers()
        {
            bool success = true;
            try
            {

                var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
                var userManager = new UserManager<ApplicationUser>(store);
                ApplicationUser user = userManager.FindByEmail("superadmin@athleteadda.com");
                if(user == null)
                {
                    user = new ApplicationUser { UserName = "superadmin@athleteadda.com", Email = "superadmin@athleteadda.com" };
                    userManager.Create(user, "athlete@123#$");
                    userManager.AddToRole(user.Id, "SuperAdmin");
                }

                ApplicationUser userPub = userManager.FindByEmail("publisher@athleteadda.com");
                if (userPub == null)
                {
                    userPub = new ApplicationUser { UserName = "publisher@athleteadda.com", Email = "publisher@athleteadda.com" };
                    userManager.Create(userPub, "publisher@123#$");
                    userManager.AddToRole(user.Id, "Publisher");
                }
            }
            catch (Exception ex)
            {
                //todo: Exception handling
                success = false;
            }
            return success;
        }
    }
}
