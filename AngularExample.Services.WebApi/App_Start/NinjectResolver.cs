﻿using Ninject;
using System.Web.Http.Dependencies;

namespace AngularExample.Services.WebApi.App_Start
{
    public class NinjectResolver: NinjectScope, IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectResolver(IKernel kernel) : base(kernel)
        {
            _kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectScope(_kernel.BeginBlock());
        }
    }
}