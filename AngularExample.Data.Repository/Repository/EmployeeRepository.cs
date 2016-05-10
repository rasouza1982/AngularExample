using AngularExample.Data.Repository.Contexts;
using AngularExample.Domain;
using AngularExample.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AngularExample.Data.Repository.Repository
{
    public class EmployeeRepository: Repository<Employee, AngularExampleContext>, IEmployeeRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public Employee ObterPorNome(string nome)
        {
            return Buscar(x => x.Name == nome).FirstOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public IEnumerable<Employee> ObterTodosPorNome(string nome)
        {
            return Buscar(x => x.Name.Contains(nome)).ToList();
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
        public IQueryable<Employee> ObterTodosPaginado<TProp>(Expression<Func<Employee, TProp>> selector, string sortOrder, string searchString, int skip, int take)
        {
            IQueryable<Employee> employees;

            if (sortOrder.Equals("asc"))
            {
                employees = DbSet
                .Where(x => searchString == null || x.Name.Contains(searchString))
                .OrderBy(selector)
                .Skip(skip)
                .Take(take);
            }
            else
            {
                employees = DbSet
                .Where(x => searchString == null || x.Name.Contains(searchString))
                .OrderByDescending(selector)
                .Skip(skip)
                .Take(take);
            }

            return employees;
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
