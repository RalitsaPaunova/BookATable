namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.BookATableContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DAL.BookATableContext context)
        {
            //  This method will be called after migrating to the latest version.

            //START the application and then run Update-Database command to execute this Seed method
            if (!context.Users.Any())
            {
                var adminUser = new Entites.User
                {
                    Email = "admin@admin.com",
                    Password = "AdminPass1",
                    Name = "administrator",
                    Phone = "0123456789",
                    IsVerify = true,

                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                context.Users.Add(adminUser);

                context.Roles.Add(new Entites.Role
                {
                    Name = "Administrator",
                    AuthActions = context.AuthActions.ToList(),
                    Users = new System.Collections.Generic.List<Entites.User>() { adminUser },


                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });
            }
        }
    }
}
