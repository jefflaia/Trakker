﻿using System.Web.Mvc;

namespace Trakker.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute("AttributeIndex", "admin/attributes", new { controller = "Attribute", action = "Index" });
            context.MapRoute("CreateType", "admin/attributes/type/create", new { controller = "Attribute", action = "CreateType" });
            context.MapRoute("EditType", "admin/attributes/type/{typeId}/edit", new { controller = "Attribute", action = "EditType" });
            context.MapRoute("CreatePriority", "admin/attributes/priority/create", new { controller = "Attribute", action = "CreatePriority" });
            context.MapRoute("EditPriority", "admin/attributes/priority/{priorityId}/edit", new { controller = "Attribute", action = "EditPriority" });
            context.MapRoute("CreateResolution", "admin/attributes/resolution/create", new { controller = "Attribute", action = "CreateResolution" });
            context.MapRoute("EditResolution", "admin/attributes/resolution/{resolutionId}/edit", new { controller = "Attribute", action = "EditResolution" });
            context.MapRoute("CreateStatus", "admin/attributes/status/create", new { controller = "Attribute", action = "CreateStatus" });
            context.MapRoute("EditStatus", "admin/attributes/status/{statusId}/edit", new { controller = "Attribute", action = "EditStatus" });

            context.MapRoute("ManagementIndex", "admin/management", new { controller = "Management", action = "Index" });
            context.MapRoute("BrowseUsers", "admin/management/users", new { controller = "Management", action = "BrowseUsers" });
            context.MapRoute("ViewUser", "admin/management/user/{userId}", new { controller = "Management", action = "ViewUser" });
            context.MapRoute("CreateUser", "admin/management/user/create", new { controller = "Management", action = "CreateUser" });
            context.MapRoute("EditUser", "admin/management/user/{userId}/edit", new { controller = "Management", action = "EditUser" });
            context.MapRoute("EditUserPassword", "admin/management/user/{userId}/password/edit", new { controller = "Management", action = "EditUserPassword" });
            context.MapRoute("BrowseProjects", "admin/management/projects", new { controller = "Management", action = "BrowseProjects" });
            context.MapRoute("ViewProject", "admin/management/project/{keyName}", new { controller = "Management", action = "ViewProject" });
            context.MapRoute("CreateProject", "admin/management/project/create", new { controller = "Management", action = "CreateProject" });
            context.MapRoute("EditProject", "admin/management/project/{keyName}/edit", new { controller = "Management", action = "EditProject" });
        }
    }
}
