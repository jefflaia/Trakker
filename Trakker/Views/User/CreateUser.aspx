<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ViewWrapperViewData<MasterViewData,Trakker.ViewData.UserData.CreateEditUserViewData>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	CreateUser
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<% using (Html.BeginForm(400))
   { %>
        <h2>Create User</h2>
        <%= Html.Partial("CreateEditUser", Model.View) %>
<% } %>


</asp:Content>
