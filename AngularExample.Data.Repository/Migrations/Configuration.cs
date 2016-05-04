namespace AngularExample.Data.Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AngularExample.Data.Repository.Contexts.AngularExampleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AngularExample.Data.Repository.Contexts.AngularExampleContext";
        }

        protected override void Seed(AngularExample.Data.Repository.Contexts.AngularExampleContext context)
        {

            context.Departments.AddOrUpdate( 
                
                
                )

            context.Employees.AddOrUpdate(
                x => x.Department, 
                );

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
        }
    }
}
