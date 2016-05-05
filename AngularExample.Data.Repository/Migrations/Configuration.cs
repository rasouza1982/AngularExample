namespace AngularExample.Data.Repository.Migrations
{
    using AngularExample.Data.Repository.Contexts;
    using AngularExample.Domain;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<AngularExampleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "AngularExample.Data.Repository.Contexts.AngularExampleContext";
        }

        protected override void Seed(AngularExampleContext context)
        {
            string FacilitiesDepartment = "Facilities";
            string HrDepartment = "Human Resources";
            string ItDepartment = "IT";


            var departments = new List<Department>
            {
                new Department() { Name = FacilitiesDepartment, DataCadastro = DateTime.Now },
                new Department() { Name = HrDepartment, DataCadastro = DateTime.Now },
                new Department() { Name = ItDepartment, DataCadastro = DateTime.Now }
            };

            departments.ForEach(s => context.Departments.AddOrUpdate(d => d.Name, s));
            //context.SaveChanges();
            SaveChanges(context);

            //new Employee() { Name = "Funcionario 1", Matricula = 1234, DepartmentId = 1, DataCadastro = DateTime.Now },
            //new Employee() { Name = "Funcionario 2", Matricula = 4733, DepartmentId = 2, DataCadastro = DateTime.Now },
            //new Employee() { Name = "Funcionario 3", Matricula = 3544, DepartmentId = 3, DataCadastro = DateTime.Now },
            //new Employee() { Name = "Funcionario 4", Matricula = 8786, DepartmentId = 3, DataCadastro = DateTime.Now }


            var employees = new List<Employee>
            {
                new Employee() { Name = "Funcionario 1", Matricula = 1, DepartmentId = 1, DataCadastro = DateTime.Now,  },
                new Employee() { Name = "Funcionario 2", Matricula = 2, DepartmentId = 2, DataCadastro = DateTime.Now },
                new Employee() { Name = "Funcionario 3", Matricula = 3, DepartmentId = 3, DataCadastro = DateTime.Now },
                new Employee() { Name = "Funcionario 4", Matricula = 4, DepartmentId = 3, DataCadastro = DateTime.Now }

                //new Employee() { Name = "Funcionario 1", Matricula = 1, DepartmentId = departments.Single(d => d.Name == FacilitiesDepartment).Id, DataCadastro = DateTime.Now },
                //new Employee() { Name = "Funcionario 2", Matricula = 2, DepartmentId = departments.Single(d => d.Name == HrDepartment).Id, DataCadastro = DateTime.Now },
                //new Employee() { Name = "Funcionario 3", Matricula = 3, DepartmentId = departments.Single(d => d.Name == ItDepartment).Id, DataCadastro = DateTime.Now },
                //new Employee() { Name = "Funcionario 4", Matricula = 4, DepartmentId = departments.Single(d => d.Name == ItDepartment).Id, DataCadastro = DateTime.Now }
            };

            employees.ForEach(s => context.Employees.AddOrUpdate(e => e.Name, s));

            //context.SaveChanges();
            SaveChanges(context);

            base.Seed(context);

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


        private void SaveChanges(DbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }

    }
}
