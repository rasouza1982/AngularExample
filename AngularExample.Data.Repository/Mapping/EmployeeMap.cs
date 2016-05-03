using AngularExample.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace AngularExample.Data.Repository.Mapping
{
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            ToTable("Employee");

            HasKey(x => x.Id);

            Property(x => x.Name).HasMaxLength(80).IsRequired();
            Property(x => x.Matricula).IsRequired();
            
            Property(x => x.DepartmentId).IsRequired();

            HasRequired(x => x.Department);           

        }
    }
}
