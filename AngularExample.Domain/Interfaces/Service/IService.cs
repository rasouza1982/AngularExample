using System.Collections.Generic;

namespace AngularExemple.Domain.Interfaces.Service
{
    public interface IService<TEntity> where TEntity : class
    {
        void Adicionar(TEntity obj);
        void Remover(TEntity obj);
        void Atualizar(TEntity obj);
        IEnumerable<TEntity> ObterTodos();
        TEntity ObterPorId(int id);        
        void Dispose();
    }
}
