using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace Trakker.Routes
{
    public static class SiteRoute
    {
        public static void AddRoutes(ref RouteCollection routes)
        {
            routes.MapRoute("SiteMenu", "menu", new { controller = "Site", action = "Menu" });
         
        }
    }
}