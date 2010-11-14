using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Trakker.Routes
{
    public static class UserRoutes
    {
        public static void AddRoutes(ref RouteCollection routes)
        {
            routes.MapRoute("Login", "login", new { controller = "User", action = "Login" }, new []{ "Trakker.Controllers" });
            routes.MapRoute("Logout", "logout", new { controller = "User", action = "Logout" }, new[] { "Trakker.Controllers" });
            routes.MapRoute("Create User", "create/user", new { controller = "User", action = "CreateUser" }, new[] { "Trakker.Controllers" });
            routes.MapRoute("Edit User", "edit/user/{userId}", new { controller = "User", action = "EditUser", userId = 0 }, new[] { "Trakker.Controllers" });
        }
    }
}