using AngularExample.Domain.Interfaces.Repository;
using AngularExemple.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;

namespace AngularExemple.Domain.Service
{
    public class Service<TEntity> : IDisposable, IService<TEntity> where TEntity : class
    {

        private readonly IRepository<TEntity> _repository;
        private bool _disposed;

        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public void Adicionar(TEntity obj)
        {
            _repository.Adicionar(obj);
        }

        public void Remover(TEntity obj)
        {
            _repository.Remover(obj);
        }

        public void Atualizar(TEntity obj)
        {
            _repository.Atualizar(obj);
        }

        public TEntity ObterPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _repository.Dispose();
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
