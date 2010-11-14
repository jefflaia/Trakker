<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CommentCreateEditViewData>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% using (Html.BeginForm())
    {%>
        <h2>Create</h2>
        <% Html.RenderPartial("CreateEditCommentForm", Model); %>
    <% } %>

</asp:Content>
