<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.master" Inherits="System.Web.Mvc.ViewPage<CreateEditTypeModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="Section">
        <h1>Edit Ticket Type</h1>
        <% Html.RenderPartial("CreateEditTypeForm", Model); %>
    </div>

</asp:Content>
