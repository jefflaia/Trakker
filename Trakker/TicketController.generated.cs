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
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace Trakker.Controllers {
    public partial class TicketController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected TicketController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult TicketDetails() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.TicketDetails);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult BrowseTickets() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.BrowseTickets);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult EditTicket() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.EditTicket);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult CreateComment() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.CreateComment);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult EditComment() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.EditComment);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Comment() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Comment);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public TicketController Actions { get { return MVC.Ticket; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Ticket";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string TicketDetails = "TicketDetails";
            public readonly string BrowseTickets = "BrowseTickets";
            public readonly string CreateTicket = "CreateTicket";
            public readonly string EditTicket = "EditTicket";
            public readonly string CreateComment = "CreateComment";
            public readonly string EditComment = "EditComment";
            public readonly string Comment = "Comment";
        }


        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string BrowseTickets = "~/Views/Ticket/BrowseTickets.aspx";
            public readonly string Comment = "~/Views/Ticket/Comment.ascx";
            public readonly string CreateComment = "~/Views/Ticket/CreateComment.aspx";
            public readonly string CreateEditCommentForm = "~/Views/Ticket/CreateEditCommentForm.ascx";
            public readonly string CreateEditTicketForm = "~/Views/Ticket/CreateEditTicketForm.ascx";
            public readonly string CreateTicket = "~/Views/Ticket/CreateTicket.aspx";
            public readonly string EditComment = "~/Views/Ticket/EditComment.aspx";
            public readonly string EditTicket = "~/Views/Ticket/EditTicket.aspx";
            public readonly string TicketDetails = "~/Views/Ticket/TicketDetails.aspx";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_TicketController: Trakker.Controllers.TicketController {
        public T4MVC_TicketController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult TicketDetails(string keyName) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.TicketDetails);
            callInfo.RouteValueDictionary.Add("keyName", keyName);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult BrowseTickets(int? index) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.BrowseTickets);
            callInfo.RouteValueDictionary.Add("index", index);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult CreateTicket() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.CreateTicket);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult CreateTicket(Trakker.Models.CreateEditTicketModel viewData) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.CreateTicket);
            callInfo.RouteValueDictionary.Add("viewData", viewData);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult EditTicket(string keyName) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.EditTicket);
            callInfo.RouteValueDictionary.Add("keyName", keyName);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult EditTicket(string keyName, Trakker.Models.CreateEditTicketModel viewData) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.EditTicket);
            callInfo.RouteValueDictionary.Add("keyName", keyName);
            callInfo.RouteValueDictionary.Add("viewData", viewData);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult CreateComment(string keyName) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.CreateComment);
            callInfo.RouteValueDictionary.Add("keyName", keyName);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult CreateComment(string keyName, Trakker.Data.Comment comment) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.CreateComment);
            callInfo.RouteValueDictionary.Add("keyName", keyName);
            callInfo.RouteValueDictionary.Add("comment", comment);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult EditComment(string keyName, int id) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.EditComment);
            callInfo.RouteValueDictionary.Add("keyName", keyName);
            callInfo.RouteValueDictionary.Add("id", id);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult EditComment(string keyName, int id, Trakker.Data.Comment comment) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.EditComment);
            callInfo.RouteValueDictionary.Add("keyName", keyName);
            callInfo.RouteValueDictionary.Add("id", id);
            callInfo.RouteValueDictionary.Add("comment", comment);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Comment(Trakker.Data.Comment comment) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Comment);
            callInfo.RouteValueDictionary.Add("comment", comment);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
