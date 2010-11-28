<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.master" Inherits="System.Web.Mvc.ViewPage<CreateEditStatusModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="Section">
        <h1>Edit Status</h1>
        <% Html.BeginForm(); %>
            <% Html.RenderPartial("CreateEditStatusForm", Model); %>
        <% Html.EndForm(); %>
    </div>

</asp:Content>
