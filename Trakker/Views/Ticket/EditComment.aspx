<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Basic.Master" Inherits="System.Web.Mvc.ViewPage<CommentCreateEditModel>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="BasicContent" runat="server">

    <h2>Edit</h2>
    
    <% Html.RenderPartial("CreateEditCommentForm"); %>

</asp:Content>
