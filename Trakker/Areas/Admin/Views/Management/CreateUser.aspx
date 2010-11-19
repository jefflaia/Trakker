<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.master" Inherits="System.Web.Mvc.ViewPage<Trakker.Areas.Admin.Models.Management.CreateEditUserModel>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<% using (Html.BeginForm())
   { %>
        <h2>Create User</h2>
        <%= Html.Partial("CreateEditUser", Model) %>
<% } %>


</asp:Content>
