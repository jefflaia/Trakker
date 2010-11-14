<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CreateEditUserViewData>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<% using (Html.BeginForm())
   { %>
        <h2>Create User</h2>
        <%= Html.Partial("CreateEditUser", Model) %>
<% } %>


</asp:Content>
