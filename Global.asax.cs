using Autofac;
using Autofac.Integration.Mvc;
using Domain;
using SDS_Technical_Exam.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SDS_Technical_Exam
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            // Create the builder
            var builder = new ContainerBuilder();

            // Register your MVC controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register your services (repositories)
            builder.RegisterType<RecyclableTypeRepository>().As<IRecyclableTypeRepository>();
            builder.RegisterType<RecyclableItemRepository>().As<IRecyclableItemRepository>();

            // Register ApplicationDBContext (Assuming it's a DbContext)
            builder.RegisterType<ApplicationDBContext>().AsSelf().InstancePerLifetimeScope();

            // Build the container
            var container = builder.Build();

            // Set the MVC Dependency Resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
