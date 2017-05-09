﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using LearningCenter.WebSite.Controllers;

namespace LearningCenter.WebSite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterAutofac();
        }

        private void RegisterAutofac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            RegisterAssemblyTypes(builder, Assembly.GetExecutingAssembly());

            var container = builder.Build();

            // Configure dependency resolver.
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private void RegisterAssemblyTypes(ContainerBuilder builder, Assembly assembly)
        {
            builder.RegisterAssemblyTypes(assembly).AsSelf().AsImplementedInterfaces();

            var assemblyNames = assembly.GetReferencedAssemblies();

            foreach (var assemblyName in assemblyNames)
            {
                if (assemblyName.FullName.ToLower().Contains("learningcenter"))
                {
                    assembly = Assembly.Load(assemblyName);
                    RegisterAssemblyTypes(builder, assembly);
                }
            }
        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError();

            // Can add Error logger/Email here

            Server.ClearError();

            var routeData = new RouteData();
            routeData.Values.Add("controller", "Error");
            routeData.Values.Add("action", "Error");

            IController errorController = new Controllers.ErrorController();
            errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
        }
    }
}