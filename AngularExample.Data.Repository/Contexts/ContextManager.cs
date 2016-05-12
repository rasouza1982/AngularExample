using System.Web;
using AngularExample.Data.Repository.Interfaces;

namespace AngularExample.Infra.Data.Contexts
{
    public class ContextManager<TContext> : IContextManager<TContext> where TContext : IDbContext, new()
    {
        private const string ContextKey = "ContextManager.Context";
        
        public IDbContext GetContext()
        {
            if (HttpContext.Current.Items[ContextKey] == null)
            {
                HttpContext.Current.Items[ContextKey] = new TContext();
            }

            return (IDbContext) HttpContext.Current.Items[ContextKey];
        }
    }
}