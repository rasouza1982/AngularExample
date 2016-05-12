using AngularExample.Domain;
using System.Data.Entity.ModelConfiguration;

namespace AngularExample.Data.Repository.Mapping
{
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            ToTable("Employee");

            HasKey(x => x.Id);
            //Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name).HasMaxLength(100).IsRequired();
            Property(x => x.Matricula).IsRequired();

            Property(x => x.DataCadastro).IsRequired();

            
            Property(x => x.DepartmentId).IsRequired();

            HasRequired(x => x.Department)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.DepartmentId);

        }
    }
}
