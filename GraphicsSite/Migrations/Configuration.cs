namespace GraphicsSite.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using GraphicsSite.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<GraphicsSite.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(GraphicsSite.Models.ApplicationDbContext context)
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
                        Id = "a59aae1c-db79-4dcb-9872-15d1c390b609",
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
                        emailOne = "test@test.com",
                        emailTwo = "test@test.com",
                        masterAccountId = "165bd383-73a4-450c-9365-a94f362660d8"
                    }, new Account()
                    {
                        ApplicationUserId = "a59aae1c-db79-4dcb-9872-15d1c390b609",
                        hasSubscribed = false,
                        isMasterAccount = true,
                        emailOne = "test@test.com",
                        emailTwo = "test@test.com",
                        masterAccountId = "165bd383-73a4-450c-9365-a94f362660d8"
                    });
                seedRoles(context);
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var outputLines = new List<string>();
                foreach (var eve in ex.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:",
                        DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format(
                            "- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage));
                    }
                }
                //Write to file
                System.IO.File.AppendAllLines("thisisafile.txt", outputLines);
                throw;

                // Showing it on screen
                throw new Exception(string.Join(",", outputLines.ToArray()));
            }
            seedRoles(context);
        }

        private void seedRoles(GraphicsSite.Models.ApplicationDbContext context)
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
