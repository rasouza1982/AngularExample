using System;
using System.Linq;
using AngularExample.Domain.Interfaces.Repository;
using Ninject;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        [Inject]
        public IEmployeeRepository employeeRepository { get; set; }
        [Inject]
        public IDepartmentRepository departmentRepository { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //repository.GetAll().FirstOrDefault();
            string FinancialDepartment = "Facilities";
            string HrDepartment = "Human Resources";
            string ItDepartment = "IT";

            Response.Write(departmentRepository.GetAll().FirstOrDefault(d => d.Name.Equals(FinancialDepartment)).Id + "</br>");
            Response.Write(departmentRepository.GetAll().FirstOrDefault(d => d.Name.Equals(HrDepartment)).Id + "</br>");
            Response.Write(departmentRepository.GetAll().FirstOrDefault(d => d.Name.Equals(ItDepartment)).Id + "</br>");

            Response.Write("<br/>");
            Response.Write(String.Format("{0}{1}{2}", "Foram econtrados ", departmentRepository.GetAll().Count(), " departamentos."));
            Response.Write(Environment.NewLine);
            Response.Write(String.Format("{0}{1}{2}", "Foram econtrados ", employeeRepository.GetAll().Count(), " empregados."));

        }
    }
}