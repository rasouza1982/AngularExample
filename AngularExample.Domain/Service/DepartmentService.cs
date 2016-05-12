using AngularExample.Domain;
using AngularExample.Domain.Interfaces.Repository;
using AngularExemple.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AngularExemple.Domain.Service
{
    public class DepartmentService : Service<Department>, IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
            :base(departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }


        public int TotalRegistros(string searchString)
        {
            return _departmentRepository.TotalRegistros(searchString);
        }

        public IEnumerable<Department> ObterTodosPaginado<TProp>(Expression<Func<Department, TProp>> selector, string sortOrder, string searchString, int skip, int take)
        {
            return _departmentRepository.ObterTodosPaginado(selector, sortOrder, searchString, skip, take);
        }

        public Department ObterPorNome(string nome)
        {
            return _departmentRepository.ObterPorNome(nome);
        }

        public IEnumerable<Department> ObterTodosPorNome(string nome)
        {
            return _departmentRepository.ObterTodosPorNome(nome);
        }
    }
}
