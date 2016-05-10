using AngularExample.Data.Repository.Contexts;
using AngularExample.Data.Repository.Interfaces;
using AngularExample.Data.Repository.Repository;
using AngularExample.Data.Repository.UoW;
using AngularExample.Domain.Interfaces.Repository;
using AngularExemple.Domain.Interfaces.Service;
using AngularExemple.Domain.Service;
using Ninject.Modules;

namespace AngularExample.Infra.Crosscutting.IoC
{
    public class NinjectModulo : NinjectModule
    {

        public override void Load()
        {

            //domain

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