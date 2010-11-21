<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Basic.Master" Inherits="System.Web.Mvc.ViewPage<CreateEditTicketModel>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="BasicContent" runat="server">

<% using (Html.BeginForm())
   { %>
    <h1>New Ticket</h1>
    <% Html.RenderPartial("CreateEditTicketForm", Model); %>
<% } %>

</asp:Content>
