using Autofac;
using Autofac.Integration.WebApi;
using Products.API.Controllers.v1_0;
using Products.Repository;
using Products.Repository.Helpers;
using Products.Repository.Helpers.Interfaces;
using Products.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;

namespace Products.API.App_Start
{
    public static class AutofacConfig
    {
        public static IContainer Container;
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(typeof(ProductsController).Assembly);
            
            builder.RegisterType<ConnectionManager>()
                .As<IConnectionManager>()
                .WithParameter(
                    new TypedParameter(
                        typeof(string),
                        WebConfigurationManager.ConnectionStrings["ProductsDB"].ConnectionString))
                .SingleInstance();

            builder.RegisterAssemblyTypes(typeof(ProductRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(ProductService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //builder.RegisterType<SimpleGuidIdGenerator>()
            //    .As<IGuidIdGenerator>()
            //    .SingleInstance();

            Container = builder.Build();

            return Container;
        }
    }
}