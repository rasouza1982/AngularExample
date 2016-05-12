using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AngularExample.Domain;
using AngularExample.Domain.Interfaces.Repository;
using AngularExample.Infra.Data.Contexts;

namespace AngularExample.Infra.Data.Repository
{
    public class DepartmentRepository : Repository<Department, AngularExampleContext>, IDepartmentRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public Department ObterPorNome(string nome)
        {
            return Buscar(x => x.Name == nome).FirstOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public IEnumerable<Department> ObterTodosPorNome(string nome)
        {
            return Buscar(x => x.Name == nome).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TProp"></typeparam>
        /// <param name="selector"></param>
        /// <param name="sortOrder"></param>
        /// <param name="searchString"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public IQueryable<Department> ObterTodosPaginado<TProp>(Expression<Func<Department, TProp>> selector, string sortOrder, string searchString, int skip, int take)
        {
            IQueryable<Department> departments;

            if (sortOrder.Equals("asc"))
            {
                departments = DbSet
                .Where(x => searchString == null || x.Name.Contains(searchString))
                .OrderBy(selector)
                .Skip(skip)
                .Take(take);
            }
            else
            {
                departments = DbSet
                .Where(x => searchString == null || x.Name.Contains(searchString))
                .OrderByDescending(selector)
                .Skip(skip)
                .Take(take);
            }

            return departments;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public int TotalRegistros(string searchString)
        {
            return DbSet.Count(x => searchString == null || x.Name.Contains(searchString));
        }
    }
}
