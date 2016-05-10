using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
