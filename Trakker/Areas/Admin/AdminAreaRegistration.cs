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
        }
    }
}
