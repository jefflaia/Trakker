<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">

    <h2>Index</h2>
    <% Html.RenderPartial("SubNavigation"); %>

</asp:Content>
