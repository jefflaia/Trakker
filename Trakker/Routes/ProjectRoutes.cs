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
            routes.MapRoute("AllProjects", "projects", new { controller = "Project", action = "AllProjects" });
            routes.MapRoute("ProjectSummary", "project/{keyName}", new { controller = "Project", action = "ProjectSummary" });
            routes.MapRoute("ComponentSummary", "component/{keyName}", new { controller = "Project", action = "ComponentSummary" });
            routes.MapRoute("CreateProject", "new/project", new { controller = "Project", action = "CreateProject" });
            routes.MapRoute("EditProject", "edit/project/{projectKeyName}", new { controller = "Project", action = "EditProject" });

        }
    }
}