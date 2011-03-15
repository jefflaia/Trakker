<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Basic.Master" Inherits="System.Web.Mvc.ViewPage<CommentCreateEditModel>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="BasicContent" runat="server">


    <%: Html.ActionLink("test", MVC.Ticket.TicketDetails("IHLThh-10")) %>
    <% using (Html.BeginForm()) {%>
        <h2>Create</h2>
        <% Html.RenderPartial("CreateEditCommentForm", Model); %>
    <% } %>

</asp:Content>
