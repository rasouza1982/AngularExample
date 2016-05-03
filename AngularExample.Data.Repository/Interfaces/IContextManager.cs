namespace AngularExample.Data.Repository.Interfaces
{
    public interface IContextManager<TContext> where TContext : IDbContext, new()
    {
        IDbContext GetContext();
    }
}