namespace Trakker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using AutoMapper;
    using Sql = Trakker.Data.Access;
    using Trakker.Data;
    using System.Web.Security;
    using System.Security.Principal;
    using Trakker.Routes;
    using System.Configuration;
    using Trakker.Core.IoC;
    using System.ComponentModel;
    using Telerik.Web.Mvc;
    using ResourceCompiler;
    using ResourceCompiler.Compressors.StyleSheet;
    using ResourceCompiler.Compressors.JavaScript;


    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            UserRoutes.AddRoutes(ref routes);
            ProjectRoutes.AddRoutes(ref routes);
            TicketRoutes.AddRoutes(ref routes);

            //routes.MapRoute("Pagination", "paginator/{count}/{page}/{pageSize}", new { controller = "Nav", action = "TicketListPagination" });
                                  
            routes.MapRoute("Default", "",  new { controller = "Ticket", action = "BrowseTickets"});
            routes.MapRoute("CSS", "{fileName}.css", new { controller = "Resource", action = "CSS" });
            routes.MapRoute("JS", "{fileName}.js", new { controller = "Resource", action = "JS" });
            routes.MapRoute(null, "{controller}/{action}", new string[]{ "Trakker.Controllers" });

        }

        protected void Application_Start()
        {
            

            AreaRegistration.RegisterAllAreas();
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory());
            RegisterRoutes(RouteTable.Routes);
            //RouteDebug.RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes);


            RecoAssets.StyleSheet()
                .Add("~/Content/Main.css")
                .Add("~/Content/Project.css")
                .AddDynamic("~/Content/Theme.css")
                .Media(MediaType.Screen)
                .Combine(true)
                .Compress(true)
                .Version(true)
                .SetCompressor(new MsCompressor());

            RecoAssets.JavaScript()
                .Add("~/Scripts/jquery-1.4.1.js")
                .Combine(true)
                .Compress(true)
                .Version(true)
                .SetCompressor(new YuiMinifier());
            /*
            SharedWebAssets
                .Scripts(config => config.AddGroup("js", group => group
                    .Add("jquery-1.4.2.min.js")
                    .Add("telerik.common.min.js")
                    .Add("telerik.datepicker.min.js")
                    .Add("telerik.calendar.min.js")
                    .Combined(true)
                ));*/
        }
    }
}