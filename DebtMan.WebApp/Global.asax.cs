﻿using System.Web.Mvc;
using System.Web.Routing;
using DebtMan.WebApp.Bootstrappers;
using DebtMan.WebApp.MvcExtensibility;

namespace DebtMan.WebApp
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            // http://stackoverflow.com/questions/487230/serving-favicon-ico-in-asp-net-mvc
            routes.IgnoreRoute("favicon.ico");

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            StructureMapBootstrapper.Initialise();
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());

            AutoMapperBootstrapper.Configure();
        }
    }
}
