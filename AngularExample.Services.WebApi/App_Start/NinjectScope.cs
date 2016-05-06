﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Activation;
using Ninject.Parameters;
using Ninject.Syntax;
using System.Web.Http.Dependencies;

namespace AngularExample.Services.WebApi.App_Start
{
    public class NinjectScope : IDependencyScope
    {
        protected IResolutionRoot ResolutionRoot;

        public NinjectScope(IResolutionRoot kernel)
        {
            ResolutionRoot = kernel;
        }


        public object GetService(Type serviceType)
        {
            IRequest request = ResolutionRoot.CreateRequest(serviceType, 
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}