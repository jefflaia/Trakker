using System.Web.Mvc;

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
            context.MapRoute("CreatePriority", "admin/attributes/priority/create", new { controller = "Attribute", action = "CreatePriority" });
            context.MapRoute("CreateResolution", "admin/attributes/resolution/create", new { controller = "Attribute", action = "CreateResolution" });

            context.MapRoute("ManagementIndex", "admin/management", new { controller = "Management", action = "Index" });
            context.MapRoute("CreateUser", "admin/management/user/create", new { controller = "Management", action = "CreateUser" });
            context.MapRoute("EditUser", "admin/management/user/{userId}/edit", new { controller = "Management", action = "EditUser", userId = 0 });
            context.MapRoute("AllProjects", "admin/management/projects", new { controller = "Management", action = "AllProjects" });
            context.MapRoute("CreateProject", "admin/management/project/create", new { controller = "Management", action = "CreateProject" });
            context.MapRoute("EditProject", "admin/management/project/{keyName}/edit", new { controller = "Management", action = "EditProject" });
        }
    }
}
