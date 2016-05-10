using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace AngularExample.Domain.Interfaces.Repository
{
    public interface IDepartmentRepository : IRepository<Department> 
    {
        Department ObterPorNome(string nome);
        IEnumerable<Department> ObterTodosPorNome(string nome);

        IQueryable<Department> ObterTodosPaginado<TProp>(Expression<Func<Department, TProp>> selector, string sortOrder,
            string searchString, int skip, int take);

        int TotalRegistros(string searchString);
    }
}
