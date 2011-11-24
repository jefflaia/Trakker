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
            
            routes.MapRoute("ProjectOverviewTab", "project/{projectId}", MVC.Project.OverviewTab());
            routes.MapRoute("ProjectRoadMapTab", "project/{projectId}/road-map", MVC.Project.RoadMapTab());
            routes.MapRoute("ProjectReleaseNotes", "project/{projectId}/version/{versionId}/release-notes", MVC.Project.ReleaseNotes());
            routes.MapRoute("ComponentSummary", "component/{keyName}", MVC.Project.ComponentSummary());

        }
    }
}