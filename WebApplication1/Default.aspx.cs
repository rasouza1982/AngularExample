using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AngularExample.Domain.Interfaces.Repository;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        private IRepositoryEmployee _repository;

        public Default()
        {
           // _repository = new RepositoryEmployee();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}