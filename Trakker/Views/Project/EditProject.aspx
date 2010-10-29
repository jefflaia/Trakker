<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CreateEditProjectViewData>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit Project: <%= Model.Name %></h2>

    <% Html.RenderPartial("CreateEditProject", Model); %>

</asp:Content>
