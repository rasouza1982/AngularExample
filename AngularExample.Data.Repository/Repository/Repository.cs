﻿using AngularExample.Data.Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AngularExample.Data.Repository.Interfaces;
using AngularExample.Domain.Interfaces.Repository;
using Microsoft.Practices.ServiceLocation;

namespace AngularExample.Data.Repository.Repository
{
    public class Repository<TEntity, TContext> : IRepository<TEntity> 
        where TEntity : class
        where TContext : IDbContext, new()

    {

        private readonly ContextManager<TContext> _contextManager = 
            ServiceLocator.Current.GetInstance<IContextManager<TContext>>() as ContextManager<TContext>;
        
        protected IDbContext Context;
        protected IDbSet<TEntity> DbSet;

        
        public Repository()
        {
            this.Context = _contextManager.GetContext();
            DbSet = Context.Set<TEntity>();
            //this._context = new AngularExampleContext();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual void Remove(TEntity obj)
        {
            DbSet.Remove(obj);
        }

        public virtual void Update(TEntity obj)
        {
            var entry = Context.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
        }

        public virtual TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}