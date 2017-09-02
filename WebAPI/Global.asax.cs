using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Entity_CodeFirst.models;
using Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterAutoFac();          
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterAutoFac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterFilterProvider();
            builder.RegisterType<StudentRepository>().As<IRepository<Student>>();
            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterModule(new DataModule("SchoolContext"));
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
