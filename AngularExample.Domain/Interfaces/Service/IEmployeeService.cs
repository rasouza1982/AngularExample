using AngularExample.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AngularExemple.Domain.Interfaces.Service
{
    public interface IEmployeeService: IService<Employee>
    {
        int TotalRegistros(string searchString);
        IEnumerable<Employee> ObterTodosPaginado<TProp>(Expression<Func<Employee, TProp>> selector, string sortOrder,
          string searchString, int skip, int take);
        Employee ObterPorNome(string nome);
        IEnumerable<Employee> ObterTodosPorNome(string nome);  
    }
}
