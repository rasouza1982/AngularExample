using AngularExample.Data.Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AngularExample.Data.Repository.Interfaces;
using AngularExample.Domain.Interfaces.Repository;
using Microsoft.Practices.ServiceLocation;
using System.Linq.Expressions;

namespace AngularExample.Data.Repository.Repository
{
    public class Repository<TEntity, TContext> : IRepository<TEntity>  
        where TEntity : class
        where TContext : IDbContext, new()

    {

        private readonly ContextManager<TContext> _contextManager = ServiceLocator.Current.GetInstance<IContextManager<TContext>>() as ContextManager<TContext>;
        private bool _disposed;
        
        protected IDbContext Context;
        protected IDbSet<TEntity> DbSet;

        
        public Repository()
        {
            Context = _contextManager.GetContext();
            DbSet = Context.Set<TEntity>();
        }

        public virtual void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual void Remover(TEntity obj)
        {
            DbSet.Remove(obj);
        }

        public virtual void Atualizar(TEntity obj)
        {
            var entry = Context.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
        }

        public virtual TEntity ObterPorId(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true); 
            GC.SuppressFinalize(this);
        }
        
    }
}
