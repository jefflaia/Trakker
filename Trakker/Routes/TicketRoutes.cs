using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Trakker.Routes
{
    public static class TicketRoutes
    {
        public static void AddRoutes(ref RouteCollection routes)
        {
            routes.MapRoute("CreateTicket", "create/ticket", new { controller = "Ticket", action = "CreateTicket" });
            routes.MapRoute("EditTicket", "edit/ticket/{keyName}", new { controller = "Ticket", action = "EditTicket" });
            routes.MapRoute("TicketDetails", "ticket/{keyName}", new { controller = "Ticket", action = "TicketDetails" });
            routes.MapRoute("CreateComment", "{keyName}/create/comment", new { controller = "Ticket", action = "CreateComment" });
            routes.MapRoute("EditComment", "{keyName}/edit/comment/{id}", new { controller = "Ticket", action = "EditComment" });

            routes.MapRoute("CreatePriority", "create/priority", new { controller = "Ticket", action = "CreatePriority" });

            routes.MapRoute("CreateResolution", "create/resolution", new { controller = "Ticket", action = "CreateResolution" });

        }
    }
}