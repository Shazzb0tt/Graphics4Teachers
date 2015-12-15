namespace Graphics4Teachers.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Graphics4Teachers.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Validation;
    using System.Diagnostics;

    internal sealed class Configuration : DbMigrationsConfiguration<Graphics4Teachers.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Graphics4Teachers.Models.ApplicationDbContext context)
        {
            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("thisisareallyawesomepassword");
            try
            {
                // Add Admin User b
                context.Users.AddOrUpdate(p => p.Id,
                    new ApplicationUser()
                    {
                        Id = "165bd383-73a4-450c-9365-a94f362660d8",
                        Name = "Lian Rudkin",
                        School = "Hamilton Boys High",
                        Email = "daniellarmour@hotmail.com",
                        PasswordHash = password,
                        UserName = "daniellarmour@hotmail.com"
                    }, new ApplicationUser()
                    {
                        Id= "a59aae1c-db79-4dcb-9872-15d1c390b609",
                        Name = "Jerry Pants",
                        School = "Hamilton Boys High2",
                        Email = "extraemail@hotmail.com",
                        PasswordHash = password,
                        UserName = "extraemail@hotmail.com"
                    });

                context.Accounts.AddOrUpdate(a => a.Id,
                    new Account()
                    {
                        ApplicationUserId = "165bd383-73a4-450c-9365-a94f362660d8",
                        hasSubscribed = true,
                        isMasterAccount = true,
                        emailOne = "",
                        emailTwo = ""
                    }, new Account()
                    {
                        ApplicationUserId = "a59aae1c-db79-4dcb-9872-15d1c390b609",
                        hasSubscribed = false,
                        isMasterAccount = true,
                        emailOne = "",
                        emailTwo = ""
                    });
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }
            }
            seedRoles(context);
        }

        private void seedRoles(Graphics4Teachers.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("admin"));
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = context.Users.Find("165bd383-73a4-450c-9365-a94f362660d8");
            ir = um.AddToRole(user.Id, "admin");
            um.UpdateSecurityStamp("165bd383-73a4-450c-9365-a94f362660d8");
            um.UpdateSecurityStamp("a59aae1c-db79-4dcb-9872-15d1c390b609");
        }
    }
}
