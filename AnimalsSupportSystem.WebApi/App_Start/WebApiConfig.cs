﻿using AnimalsSupportSystem.Business.Domain;
using AnimalsSupportSystem.Infrastucture.Context;
using AnimalsSupportSystem.WebApi.IoC;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace AnimalsSupportSystem.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IAnimalSystemDbContext, AnimalSystemDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IAnimalSystemDbContextFactory<IAnimalSystemDbContext>, AnimalSystemDbContextFactory>(new HierarchicalLifetimeManager());
            container.RegisterType<ICommandFactory, CommandFactory>(new HierarchicalLifetimeManager());
            container.RegisterType<IMedicalHandler, MedicalHandler>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
