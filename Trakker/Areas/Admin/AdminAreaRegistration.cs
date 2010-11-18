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
            context.MapRoute("CreatePriority", "admin/priority/create", new { controller = "Attribute", action = "CreatePriority" });
            context.MapRoute("CreateResolution", "admin/resolution/create", new { controller = "Attribute", action = "CreateResolution" });
        }
    }
}
