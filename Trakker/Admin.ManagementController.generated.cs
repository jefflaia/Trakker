// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace Trakker.Areas.Admin.Controllers {
    public partial class ManagementController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected ManagementController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult ViewUser() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.ViewUser);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult EditUser() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.EditUser);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult EditUserPassword() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.EditUserPassword);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult ViewProject() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.ViewProject);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult EditProject() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.EditProject);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ManagementController Actions { get { return MVC.Admin.Management; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "Admin";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Management";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string Index = "Index";
            public readonly string BrowseUsers = "BrowseUsers";
            public readonly string ViewUser = "ViewUser";
            public readonly string CreateUser = "CreateUser";
            public readonly string EditUser = "EditUser";
            public readonly string EditUserPassword = "EditUserPassword";
            public readonly string BrowseProjects = "BrowseProjects";
            public readonly string ViewProject = "ViewProject";
            public readonly string CreateProject = "CreateProject";
            public readonly string EditProject = "EditProject";
            public readonly string UploadFile = "UploadFile";
        }


        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string BrowseProjects = "~/Areas/Admin/Views/Management/BrowseProjects.cshtml";
            public readonly string BrowseUsers = "~/Areas/Admin/Views/Management/BrowseUsers.cshtml";
            public readonly string CreateProject = "~/Areas/Admin/Views/Management/CreateProject.aspx";
            public readonly string CreateUser = "~/Areas/Admin/Views/Management/CreateUser.aspx";
            public readonly string EditProject = "~/Areas/Admin/Views/Management/EditProject.cshtml";
            public readonly string EditUser = "~/Areas/Admin/Views/Management/EditUser.aspx";
            public readonly string EditUserPassword = "~/Areas/Admin/Views/Management/EditUserPassword.aspx";
            public readonly string Index = "~/Areas/Admin/Views/Management/Index.aspx";
            public readonly string ViewProject = "~/Areas/Admin/Views/Management/ViewProject.aspx";
            public readonly string ViewUser = "~/Areas/Admin/Views/Management/ViewUser.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_ManagementController: Trakker.Areas.Admin.Controllers.ManagementController {
        public T4MVC_ManagementController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Index() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Index);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult BrowseUsers() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.BrowseUsers);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult ViewUser(int userId) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.ViewUser);
            callInfo.RouteValueDictionary.Add("userId", userId);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult CreateUser() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.CreateUser);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult CreateUser(Trakker.Models.Admin.Management.CreateUserModel viewModel) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.CreateUser);
            callInfo.RouteValueDictionary.Add("viewModel", viewModel);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult EditUser(int userId) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.EditUser);
            callInfo.RouteValueDictionary.Add("userId", userId);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult EditUser(int userId, Trakker.Models.Admin.Management.EditUserModel viewModel) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.EditUser);
            callInfo.RouteValueDictionary.Add("userId", userId);
            callInfo.RouteValueDictionary.Add("viewModel", viewModel);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult EditUserPassword(int userId) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.EditUserPassword);
            callInfo.RouteValueDictionary.Add("userId", userId);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult EditUserPassword(int userId, Trakker.Models.Admin.Management.EditUserPasswordModel viewModel) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.EditUserPassword);
            callInfo.RouteValueDictionary.Add("userId", userId);
            callInfo.RouteValueDictionary.Add("viewModel", viewModel);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult BrowseProjects() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.BrowseProjects);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult ViewProject(string keyName) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.ViewProject);
            callInfo.RouteValueDictionary.Add("keyName", keyName);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult CreateProject() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.CreateProject);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult CreateProject(Trakker.Models.Admin.Management.CreateProjectModel viewModel) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.CreateProject);
            callInfo.RouteValueDictionary.Add("viewModel", viewModel);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult EditProject(string keyName) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.EditProject);
            callInfo.RouteValueDictionary.Add("keyName", keyName);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult EditProject(string keyName, Trakker.Models.Admin.Management.EditProjectModel viewModel) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.EditProject);
            callInfo.RouteValueDictionary.Add("keyName", keyName);
            callInfo.RouteValueDictionary.Add("viewModel", viewModel);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult UploadFile() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.UploadFile);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
