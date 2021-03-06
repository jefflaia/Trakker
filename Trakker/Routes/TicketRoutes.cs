﻿using System;
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
            routes.MapRoute("EditTicket", "ticket/{keyName}/edit", new { controller = "Ticket", action = "EditTicket" });
            routes.MapRoute("TicketDetails", "ticket/{keyName}", new { controller = "Ticket", action = "TicketDetails" });
            routes.MapRoute("CreateComment", "{keyName}/create/comment", new { controller = "Ticket", action = "CreateComment" });
            routes.MapRoute("EditComment", "{keyName}/edit/comment/{id}", new { controller = "Ticket", action = "EditComment" });
            routes.MapRoute("BrowseTickets", "tickets/page/{index}", new { controller = "Ticket", action = "BrowseTickets", index = 1 });

        }
    }
}