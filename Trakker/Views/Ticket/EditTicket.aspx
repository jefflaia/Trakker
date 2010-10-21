<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CreateEditViewData>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% using (Html.BeginForm(800))
   {%>
    <h1>Ticket: <%= Model.Ticket.KeyName %></h1>
    <% Html.RenderPartial("CreateEditticketForm", Model); %>
<% }  %>

</asp:Content>
