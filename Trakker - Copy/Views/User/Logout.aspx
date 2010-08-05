<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ViewWrapperViewData<MasterViewData, LogoutViewData>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Logout
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Logged Out</h2>
    <p>You have been successfully logged out. Please click <%= Html.ActionLink<UserController>(x => x.Login(), "here") %> to log-in.</p>

</asp:Content>
