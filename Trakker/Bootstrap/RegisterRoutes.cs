using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Trakker.Routes;
using System;
using System.Web.Mvc;



namespace Trakker.Bootstrap
{
    public class RegisterRoutes : IBootstrapperTask
    {
        private RouteCollection _routes;

        public RegisterRoutes()
            : this(RouteTable.Routes)
        {
        }

        public RegisterRoutes(RouteCollection routes)
        {
            _routes = routes;
        }

        public void Execute()
        {
            //all routes must be added starting here
            _routes.Clear();

            _routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            UserRoutes.AddRoutes(ref _routes);
            ProjectRoutes.AddRoutes(ref _routes);
            TicketRoutes.AddRoutes(ref _routes);

            //routes.MapRoute("Pagination", "paginator/{count}/{page}/{pageSize}", new { controller = "Nav", action = "TicketListPagination" });

            /**** SearchController ****/
            _routes.MapRoute("SearchIndex", "search", new { controller = "Search", action = "SearchIndex" });
            //routes.MapRoute("SearchIndex", "", new { controller = "Search", action = "SearchIndex" });

            /**** ErrorController ****/
            _routes.MapRoute("PageNotFound", "page-not-found", new { controller = "Error", action = "PageNotFound" });
            _routes.MapRoute("TicketNotFound", "ticket-not-found", new { controller = "Error", action = "TicketNotFound" });
            _routes.MapRoute("UserNotFound", "user-not-found", new { controller = "Error", action = "UserNotFound" });
            _routes.MapRoute("UnexpectedError", "unexpected-error", new { controller = "Error", action = "UnexpectedError" });
            _routes.MapRoute("InvalidAction", "invalid-action", new { controller = "Error", action = "InvalidAction" });

            /**** ResourceController ****/
            _routes.MapRoute("CSS", "{fileName}.css", new { controller = "Resource", action = "CSS" });
            _routes.MapRoute("JS", "{fileName}.js", new { controller = "Resource", action = "JS" });

            /**** Other *****/
            _routes.MapRoute("Default", "", new { controller = "Ticket", action = "BrowseTickets" });
            _routes.MapRoute(null, "{controller}/{action}", new string[] { "Trakker.Controllers" });
        }
    }
}