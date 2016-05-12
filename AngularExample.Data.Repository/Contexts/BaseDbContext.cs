using System.Data.Entity;
using AngularExample.Data.Repository.Interfaces;

namespace AngularExample.Infra.Data.Contexts
{
    public class BaseDbContext : DbContext, IDbContext
    {
        public BaseDbContext(string nameOrConnectionString)
            :base(nameOrConnectionString)
        {
                
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}