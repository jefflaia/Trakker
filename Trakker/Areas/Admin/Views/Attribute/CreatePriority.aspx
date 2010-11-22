<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.master" Inherits="System.Web.Mvc.ViewPage<CreateEditPriorityModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <% using(Html.BeginForm()) { %>
        <h2>Create Priority</h2>
        <% Html.RenderPartial("CreateEditPriorityForm"); %>
    <% } %>

</asp:Content>
