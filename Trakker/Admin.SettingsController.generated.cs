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
    public partial class SettingsController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected SettingsController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult EditColorPalette() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.EditColorPalette);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult SelectColorPalette() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.SelectColorPalette);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public SettingsController Actions { get { return MVC.Admin.Settings; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "Admin";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Settings";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string Index = "Index";
            public readonly string BrowseColorPalettes = "BrowseColorPalettes";
            public readonly string CreateColorPalette = "CreateColorPalette";
            public readonly string EditColorPalette = "EditColorPalette";
            public readonly string SelectColorPalette = "SelectColorPalette";
        }


        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string _CreateEditColorPalette = "~/Areas/Admin/Views/Settings/_CreateEditColorPalette.cshtml";
            public readonly string BrowseColorPalettes = "~/Areas/Admin/Views/Settings/BrowseColorPalettes.cshtml";
            public readonly string CreateColorPalette = "~/Areas/Admin/Views/Settings/CreateColorPalette.cshtml";
            public readonly string EditColorPalette = "~/Areas/Admin/Views/Settings/EditColorPalette.cshtml";
            public readonly string Index = "~/Areas/Admin/Views/Settings/Index.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_SettingsController: Trakker.Areas.Admin.Controllers.SettingsController {
        public T4MVC_SettingsController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Index() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Index);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult BrowseColorPalettes() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.BrowseColorPalettes);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult CreateColorPalette() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.CreateColorPalette);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult CreateColorPalette(Trakker.Models.Admin.Settings.CreateEditColorPaletteModel viewModel) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.CreateColorPalette);
            callInfo.RouteValueDictionary.Add("viewModel", viewModel);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult EditColorPalette(int paletteId) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.EditColorPalette);
            callInfo.RouteValueDictionary.Add("paletteId", paletteId);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult EditColorPalette(int paletteId, Trakker.Models.Admin.Settings.CreateEditColorPaletteModel viewModel) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.EditColorPalette);
            callInfo.RouteValueDictionary.Add("paletteId", paletteId);
            callInfo.RouteValueDictionary.Add("viewModel", viewModel);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult SelectColorPalette(int paletteId) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.SelectColorPalette);
            callInfo.RouteValueDictionary.Add("paletteId", paletteId);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
