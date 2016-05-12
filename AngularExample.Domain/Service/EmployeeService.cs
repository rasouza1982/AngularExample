using AngularExample.Domain;
using AngularExample.Domain.Interfaces.Repository;
using AngularExemple.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AngularExemple.Domain.Service
{
    public class EmployeeService : Service<Employee>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository) 
            : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        public int TotalRegistros(string searchString)
        {
            return _employeeRepository.TotalRegistros(searchString);
        }

        public IEnumerable<Employee> ObterTodosPaginado<TProp>(Expression<Func<Employee, TProp>> selector, string sortOrder, string searchString, int skip, int take)
        {
            return _employeeRepository.ObterTodosPaginado(selector, sortOrder, searchString, skip, take);
        }

        public Employee ObterPorNome(string nome)
        {
            return _employeeRepository.ObterPorNome(nome);
        }

        public IEnumerable<Employee> ObterTodosPorNome(string nome)
        {
            return _employeeRepository.ObterTodosPorNome(nome);
        }
    }
}
