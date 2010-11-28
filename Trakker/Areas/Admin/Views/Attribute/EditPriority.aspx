<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.master" Inherits="System.Web.Mvc.ViewPage<CreateEditPriorityModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="Section">
        <% Html.BeginForm(); %>
            <h1>Create Priority</h1>
            <% Html.RenderPartial("CreateEditPriorityForm"); %>
        <% Html.EndForm(); %>
    </div>

</asp:Content>
