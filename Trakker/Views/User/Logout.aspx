<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Basic.Master" Inherits="System.Web.Mvc.ViewPage<LogoutViewData>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="BasicContent" runat="server">

    <h2>Logged Out</h2>
    <p>You have been successfully logged out. Please click <%= Html.ActionLink<UserController>(x => x.Login(), "here") %> to log-in.</p>

</asp:Content>
