using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AngularExample.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        void Remove(TEntity obj);
        void Update(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
