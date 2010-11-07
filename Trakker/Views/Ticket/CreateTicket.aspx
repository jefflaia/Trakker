<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CreateEditTicketViewData>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<% using (Html.BeginForm(800))
   { %>
    <h1>New Ticket</h1>
    <% Html.RenderPartial("CreateEditTicketForm", Model); %>
<% } %>

</asp:Content>
