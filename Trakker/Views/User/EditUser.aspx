<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Basic.Master" Inherits="System.Web.Mvc.ViewPage<Trakker.ViewData.UserData.CreateEditUserViewData>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="BasicContent" runat="server">

<% using (Html.BeginForm(400))
   { %>
    <h2>Edit User: <%= Model.Email %></h2>
    <%= Html.Partial("CreateEditUser", Model) %>
<% } %>
</asp:Content>
