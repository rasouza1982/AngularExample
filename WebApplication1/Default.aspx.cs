using System;
using System.Linq;
using AngularExample.Domain.Interfaces.Repository;
using Ninject;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        [Inject]
        public IEmployeeRepository repository { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //repository.GetAll().FirstOrDefault();
            Response.Write(String.Format("{0}{1}{2}", "Foram econtrados ", repository.GetAll().Count(), " registros."));
        }
    }
}