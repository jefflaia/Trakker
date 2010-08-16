using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using Sql = Trakker.Data.Access.SqlServer;
using Trakker.Data;
using Trakker.ViewData.TicketData;
using System.Web.Security;
using System.Security.Principal;

namespace Trakker
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            routes.MapRoute("Login", "login", new { controller = "User", action = "Login" });
            routes.MapRoute("Logout", "logout", new { controller = "User", action = "Logout" });
            routes.MapRoute("Create User", "create/user", new { controller = "User", action = "CreateUser" }); 
            routes.MapRoute("Edit User", "edit/user", new { controller = "User", action = "EditUser" }); 

            routes.MapRoute("AllProjects", "projects", new { controller = "Project", action = "AllProjects" });
            routes.MapRoute("ProjectSummary", "project/{keyName}", new { controller = "Project", action = "ProjectSummary" });
            routes.MapRoute("ComponentSummary", "component/{keyName}", new { controller = "Project", action = "ComponentSummary" });
            routes.MapRoute("CreateProject", "new/project", new { controller = "Project", action = "CreateProject" });
            routes.MapRoute("EditProject", "edit/project/{projectKeyName}", new { controller = "Project", action = "EditProject" });

            routes.MapRoute("CreateTicket", "new", new { controller = "Ticket", action = "CreateTicket" });
            routes.MapRoute("EditTicket", "edit/{keyName}", new { controller = "Ticket", action = "EditTicket" });
            routes.MapRoute("TicketDetails", "{keyName}", new { controller = "Ticket", action = "TicketDetails" });
            routes.MapRoute("CreateComment", "{keyName}/comment", new { controller = "Ticket", action = "CreateComment" });
            routes.MapRoute("EditComment", "{keyName}/comment/edit/{id}", new { controller = "Ticket", action = "EditComment" });
            routes.MapRoute("DefaultPaginated", "page/{index}", new { controller = "Ticket", action = "TicketList"});
            routes.MapRoute("Default", "",  new { controller = "Ticket", action = "TicketList"});

        }

        protected void Application_Start()
        {
            Mapper.CreateMap<Comment, CommentViewData>();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}