using System;
using System.Linq;
using AngularExample.Application.Interfaces;
using AngularExample.Domain.Interfaces.Repository;
using Ninject;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        //[Inject]
        //public IEmployeeRepository employeeRepository { get; set; }
        //[Inject]
        //public IDepartmentRepository departmentRepository { get; set; }

        
        [Inject]
        public IEmployeeAppService employeeAppService { get; set; }
        
        [Inject]
        public IDepartmentAppService departmentAppService { get; set; }

        

        protected void Page_Load(object sender, EventArgs e)
        {
            const string financialDepartment = "Facilities";
            const string hrDepartment = "Human Resources";
            const string itDepartment = "IT";

            var lista = employeeAppService.ObterTodos();

            foreach (var employee in lista)
            {
                Response.Write(string.Format("{0} {1} {2}<br/>",employee.Id,employee.Name, employee.DataCadastro));
            }

            var listaDepartments = departmentAppService.ObterTodos();

            foreach (var department in listaDepartments)
            {
                Response.Write(string.Format("{0} {1} {2}<br/>", department.Id, department.Name, department.DataCadastro));
            }

            employeeAppService.Dispose();
            departmentAppService.Dispose();


            //Response.Write(departmentRepository.ObterTodos().FirstOrDefault(d => d.Name.Equals(financialDepartment)).Id + "</br>");
            //Response.Write(departmentRepository.ObterTodos().FirstOrDefault(d => d.Name.Equals(hrDepartment)).Id + "</br>");
            //Response.Write(departmentRepository.ObterTodos().FirstOrDefault(d => d.Name.Equals(itDepartment)).Id + "</br>");

            //Response.Write("<br/>");
            //Response.Write(String.Format("{0}{1}{2}", "Foram econtrados ", departmentRepository.ObterTodos().Count(), " departamentos."));
            //Response.Write(Environment.NewLine);
            //Response.Write(String.Format("{0}{1}{2}", "Foram econtrados ", employeeRepository.ObterTodos().Count(), " empregados."));

        }
    }
}