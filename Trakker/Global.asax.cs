using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using Sql = Trakker.Data.Access;
using Trakker.Data;
using Trakker.ViewData.TicketData;
using System.Web.Security;
using System.Security.Principal;
using Castle.Windsor;
using Trakker.Routes;
using System.Configuration;
using Trakker.IoC;

namespace Trakker
{
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
                        
            routes.MapRoute("DefaultPaginated", "page/{index}", new { controller = "Ticket", action = "TicketList"});
            routes.MapRoute("Default", "",  new { controller = "Ticket", action = "TicketList"});

        }

        protected void Application_Start()
        {
            Mapper.CreateMap<Comment, CommentViewData>();

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory());

            RegisterRoutes(RouteTable.Routes);
        }
    }
}