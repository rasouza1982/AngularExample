using AngularExample.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace AngularExample.Data.Repository.Mapping
{
    public class DepartmentMap: EntityTypeConfiguration<Department>
    {
        public DepartmentMap()
        {
            ToTable("Department");

            HasKey(x => x.Id);
            Property(x => x.Name).HasMaxLength(100).IsRequired();

            HasMany(x => x.Employees)
              .WithRequired(x => x.Department);

        }
    }
}
