<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CreateEditTicketViewData>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% using (Html.BeginForm())
   {%>
    <h1>Ticket: <%= Model.KeyName %></h1>
    <% Html.RenderPartial("CreateEditticketForm", Model); %>
<% }  %>

</asp:Content>
