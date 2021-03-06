﻿using AngularExample.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AngularExemple.Domain.Interfaces.Service
{
    public interface IDepartmentService: IService<Department>
    {
        int TotalRegistros(string searchString);
        IEnumerable<Department> ObterTodosPaginado<TProp>(Expression<Func<Department, TProp>> selector, string sortOrder,
          string searchString, int skip, int take);
        Department ObterPorNome(string nome);
        IEnumerable<Department> ObterTodosPorNome(string nome);  
    }
}
