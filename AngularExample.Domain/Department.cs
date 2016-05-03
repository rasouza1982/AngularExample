using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AngularExample.Domain
{
    public class Department
    {
        public Department()
        {
            this.Employees = new List<Employee>();
        }

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
