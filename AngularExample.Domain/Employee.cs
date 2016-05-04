using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AngularExample.Domain
{
    public class Employee
    {
        public Employee()
        {
            this.Department = new Department();
        }

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Matricula { get; set; }
        public virtual DateTime DataCadastro { get; set; }
        public virtual int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
