<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CreateEditProjectViewData>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% using (Html.BeginForm(600))
       {%>
        <h2>Create Project</h2>

        <% Html.RenderPartial("CreateEditProject"); %>
    <% } %>

</asp:Content>
