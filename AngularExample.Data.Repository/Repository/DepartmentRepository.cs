using AngularExample.Data.Repository.Contexts;
using AngularExample.Domain;
using AngularExample.Domain.Interfaces.Repository;

namespace AngularExample.Data.Repository.Repository
{
    public class DepartmentRepository : Repository<Department, AngularExampleContext>, IDepartmentRepository
    {
    }
}
