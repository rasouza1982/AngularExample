using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace AngularExample.Domain.Interfaces.Repository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Employee ObterPorNome(string nome);
        IEnumerable<Employee> ObterTodosPorNome(string nome);

        IQueryable<Employee> ObterTodosPaginado<TProp>(Expression<Func<Employee, TProp>> selector, string sortOrder,
            string searchString, int skip, int take);

        int TotalRegistros(string searchString);
    }
}
