<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.master" Inherits="System.Web.Mvc.ViewPage<CreateEditResolutionModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="Section">
        <h1>Edit Resolution</h1>
        <% Html.BeginForm(); %>
            <% Html.RenderPartial("CreateEditResolutionForm"); %>
        <% Html.EndForm(); %>
    </div>

</asp:Content>
