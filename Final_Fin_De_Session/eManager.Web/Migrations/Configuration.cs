using System.Web.Security;
using eManager.Domain;

namespace eManager.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<eManager.Web.Infrastrucre.DepartmentDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(eManager.Web.Infrastrucre.DepartmentDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Departments.AddOrUpdate(d => d.Name,
                new Department() {Name = "Engineering"},
                new Department() {Name = "Sales"},
                new Department() {Name = "Shipping"},
                new Department() {Name = "Human Resource"}
                );

            if (!Roles.RoleExists("Admin"))
            {
                Roles.CreateRole("Admin");
            }

            if (Membership.GetUser("admin@cgi.com") == null)
            {
                Membership.CreateUser("admin@cgi.com", "123@Abc");
                Roles.AddUserToRole("admin@cgi.com", "Admin");

            }
        }
    }
}
