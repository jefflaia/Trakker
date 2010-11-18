<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.master" Inherits="System.Web.Mvc.ViewPage<Trakker.Areas.Admin.Models.Attribute.CreateEditResolutionModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <% using (Html.BeginForm())
       { %>
        <h2>Create Resolution</h2>
        <% Html.RenderPartial("CreateEditResolutionForm"); %>

    <% } %>

</asp:Content>
