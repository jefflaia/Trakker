<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Trakker.ViewData.TicketData.CreateEditPriorityViewData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <% using(Html.BeginForm(400)) { %>
        <h2>Create Priority</h2>
        <% Html.RenderPartial("CreateEditPriorityForm"); %>
    <% } %>
</asp:Content>
