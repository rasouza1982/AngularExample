using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AngularExample.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Adicionar(TEntity obj);
        void Remover(TEntity obj);
        void Atualizar(TEntity obj);
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTodos();
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
    }
}
