<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.master" Inherits="System.Web.Mvc.ViewPage<Trakker.Areas.Admin.Models.Attribute.CreateEditPriorityModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<%= Html.ActionLink("Click me", "CreatePriority", new { controller = "Attribute", area = "admin" })  %>

    <% using(Html.BeginForm()) { %>
        <h2>Create Priority</h2>
        <% Html.RenderPartial("CreateEditPriorityForm"); %>
    <% } %>

    <div id="Due" class="t-widget t-datepicker"><input value="" title="Due" name="Due" id="Due-input" class="t-input" autocomplete="off"><a title="Open the calendar" tabindex="-1" href="#" class="t-link t-icon t-icon-calendar">select date</a></div>

</asp:Content>
