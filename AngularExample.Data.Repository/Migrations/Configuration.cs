using AngularExample.Infra.Data.Contexts;
using AngularExample.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace AngularExample.Data.Repository.Migrations
{


    internal sealed class Configuration : DbMigrationsConfiguration<AngularExampleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "AngularExample.Data.Repository.Contexts.AngularExampleContext";
        }

        protected override void Seed(AngularExampleContext context)
        {
            const string facilitiesDepartment = "Facilities";
            const string hrDepartment = "Human Resources";
            const string itDepartment = "IT";


            var departments = new List<Department>
            {
                new Department() {Name = facilitiesDepartment, DataCadastro = DateTime.Now , Employees = new List<Employee>()},
                new Department() {Name = hrDepartment, DataCadastro = DateTime.Now, Employees = new List<Employee>()},
                new Department() {Name = itDepartment, DataCadastro = DateTime.Now, Employees = new List<Employee>()}
            };

            departments.ForEach(s => context.Departments.AddOrUpdate(d => d.Name, s));

            SaveChanges(context);

            var employees = new List<Employee>
            {
                new Employee() {Name = "Funcionario 1", Matricula = 1, DepartmentId = departments.FirstOrDefault(x => x.Name == facilitiesDepartment).Id, DataCadastro = DateTime.Now, Department = departments.FirstOrDefault(x => x.Name == facilitiesDepartment)},
                new Employee() {Name = "Funcionario 2", Matricula = 2, DepartmentId = departments.FirstOrDefault(x => x.Name == hrDepartment).Id, DataCadastro = DateTime.Now, Department = departments.FirstOrDefault(x => x.Name == hrDepartment) },
                new Employee() {Name = "Funcionario 3", Matricula = 3, DepartmentId = departments.FirstOrDefault(x => x.Name == itDepartment).Id, DataCadastro = DateTime.Now, Department = departments.FirstOrDefault(x => x.Name == itDepartment) },
                new Employee() {Name = "Funcionario 4", Matricula = 4, DepartmentId = departments.FirstOrDefault(x => x.Name == itDepartment).Id, DataCadastro = DateTime.Now, Department = departments.FirstOrDefault(x => x.Name == itDepartment) }
            };

            employees.ForEach(s => context.Employees.AddOrUpdate(e => e.Matricula, s));
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

                // Add the original exception as the innerException
                throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb.ToString(), ex); 
            }
        }

    }
}
