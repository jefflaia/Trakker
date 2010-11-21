<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Basic.Master" Inherits="System.Web.Mvc.ViewPage<LogoutModel>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="BasicContent" runat="server">

    <h2>Logged Out</h2>
    <p>You have been successfully logged out. Please click <%= Html.RouteLink("here", "Login") %> to log-in.</p>

</asp:Content>
