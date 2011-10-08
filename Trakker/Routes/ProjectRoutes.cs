using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Trakker.Routes
{
    public static class ProjectRoutes
    {
        public static void AddRoutes(ref RouteCollection routes)
        {
            
            routes.MapRoute("ProjectOverviewTab", "project/{keyName}", new { controller = "Project", action = "OverviewTab" });
            routes.MapRoute("ProjectRoadMapTab", "project/{keyName}/road-map", new { controller = "Project", action = "RoadMapTab" });
            routes.MapRoute("ComponentSummary", "component/{keyName}", new { controller = "Project", action = "ComponentSummary" });

        }
    }
}