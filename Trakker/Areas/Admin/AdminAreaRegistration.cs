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
            //AttributeController
            context.MapRoute("AttributeIndex", "admin/attributes", new { controller = "Attribute", action = "Index" });
            context.MapRoute("CreateType", "admin/attributes/type/create", new { controller = "Attribute", action = "CreateType" });
            context.MapRoute("EditType", "admin/attributes/type/{typeId}/edit", new { controller = "Attribute", action = "EditType" });
            context.MapRoute("CreatePriority", "admin/attributes/priority/create", new { controller = "Attribute", action = "CreatePriority" });
            context.MapRoute("EditPriority", "admin/attributes/priority/{priorityId}/edit", new { controller = "Attribute", action = "EditPriority" });
            context.MapRoute("CreateResolution", "admin/attributes/resolution/create", new { controller = "Attribute", action = "CreateResolution" });
            context.MapRoute("EditResolution", "admin/attributes/resolution/{resolutionId}/edit", new { controller = "Attribute", action = "EditResolution" });
            context.MapRoute("CreateStatus", "admin/attributes/status/create", new { controller = "Attribute", action = "CreateStatus" });
            context.MapRoute("EditStatus", "admin/attributes/status/{statusId}/edit", new { controller = "Attribute", action = "EditStatus" });

            //ManagementController
            context.MapRoute("ManagementIndex", "admin/management", new { controller = "Management", action = "Index" });
            context.MapRoute("BrowseUsers", "admin/management/users", new { controller = "Management", action = "BrowseUsers" });
            context.MapRoute("CreateUser", "admin/management/user/create", new { controller = "Management", action = "CreateUser" });
            context.MapRoute("ViewUser", "admin/management/user/{userId}", new { controller = "Management", action = "ViewUser" });
            context.MapRoute("EditUser", "admin/management/user/{userId}/edit", new { controller = "Management", action = "EditUser" });
            context.MapRoute("EditUserPassword", "admin/management/user/{userId}/password/edit", new { controller = "Management", action = "EditUserPassword" });
            context.MapRoute("BrowseProjects", "admin/management/projects", new { controller = "Management", action = "BrowseProjects" });
            context.MapRoute("CreateProject", "admin/management/project/create", new { controller = "Management", action = "CreateProject" });
            context.MapRoute("ViewProject", "admin/management/project/{keyName}", new { controller = "Management", action = "ViewProject" });
            context.MapRoute("EditProject", "admin/management/project/{keyName}/edit", new { controller = "Management", action = "EditProject" });
            context.MapRoute("ManageVersions", "admin/management/project/{keyName}/versions", MVC.Admin.Management.ManageVersions());
            context.MapRoute("EditVersion", "admin/management/project/{keyName}/version/{versionId}/edit", MVC.Admin.Management.EditVersion());
            context.MapRoute("DeleteVersion", "admin/management/project/{projectId}/version/{versionId}/delete", MVC.Admin.Management.DeleteVersion());
            context.MapRoute("ReleaseVersion", "admin/management/project/{projectId}/version/{versionId}/release", MVC.Admin.Management.ReleaseVersion());

            //SettingsController
            context.MapRoute("SettingsIndex", "admin/settings/", new { controller = "Settings", action = "Index" });
            context.MapRoute("BrowseColorPalettes", "admin/settings/color-palettes", new { controller = "Settings", action = "BrowseColorPalettes" });
            context.MapRoute("CreateColorPalette", "admin/settings/color-palette/create", new { controller = "Settings", action = "CreateColorPalette" });
            context.MapRoute("EditColorPalette", "admin/settings/color-palette/{paletteId}/edit", new { controller = "Settings", action = "EditColorPalette" });
            context.MapRoute("SelectColorPalette", "admin/settings/color-palette/{paletteId}/select", new { controller = "Settings", action = "SelectColorPalette" });

            context.MapRoute("TestUploading", "admin/upload-file", MVC.Admin.Management.UploadFile());

        }
    }
}
