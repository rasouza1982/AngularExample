using AngularExample.Infra.Crosscutting.IoC;
using AngularExample.Services.WebApi.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AngularExample.Services.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(new Container().GetModule());

            var appXmlType =
            config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");

            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

        }

    }
}
