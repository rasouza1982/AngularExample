using AngularExample.Application;
using AngularExample.Application.Interfaces;
using AngularExample.Data.Repository.Interfaces;
using AngularExample.Domain.Interfaces.Repository;
using AngularExample.Infra.Data.Contexts;
using AngularExample.Infra.Data.Repository;
using AngularExample.Infra.Data.UoW;
using AngularExemple.Domain.Interfaces.Service;
using AngularExemple.Domain.Service;
using Ninject.Modules;

namespace AngularExample.Infra.Crosscutting.IoC
{
    public class NinjectModulo : NinjectModule
    {

        public override void Load()
        {

            //application
            //Bind<IAppService>().To<AppService>();
            Bind<IDepartmentAppService>().To<DepartmentAppService>();
            Bind<IEmployeeAppService>().To<EmployeeAppService>();

            //domain service
            Bind<IDepartmentService>().To<DepartmentService>();
            Bind<IEmployeeService>().To<EmployeeService>();

            //repositories
            Bind(typeof (IRepository<>)).To(typeof (Repository<,>));
            Bind<IDepartmentRepository>().To<DepartmentRepository>();
            Bind<IEmployeeRepository>().To<EmployeeRepository>();
            
            // data configs
            Bind(typeof(IContextManager<>)).To(typeof(ContextManager<>));
            Bind<IDbContext>().To<AngularExampleContext>();
            Bind(typeof(IUnitOfWork<>)).To(typeof(UnitOfWork<>));
        }
    }
}