<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Trakker.ViewData.TicketData.CreateEditResolutionViewData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <% using (Html.BeginForm())
       { %>
        <h2>Create Resolution</h2>
        <% Html.RenderPartial("CreateEditResolutionForm"); %>

    <% } %>

</asp:Content>
