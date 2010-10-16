<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CreateEditViewData>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Create a new ticket:</h3>
    <% Html.RenderPartial("CreateEditTicketForm", Model); %>

</asp:Content>
