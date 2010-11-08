<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ProjectSummaryViewData>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%= Model.Project.Name %>: <em><%= Model.Project.KeyName %></em></h2>
    
    <h3>Newest Tickets</h3>


</asp:Content>
