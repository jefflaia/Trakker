<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.master" Inherits="System.Web.Mvc.ViewPage<CreateEditResolutionModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="Section">
        <h1>View Resolutions</h1>
        <p>The table below shows the resolutions used by this system.</p>
        <p>Scroll down to create a resolution.</p>
    </div>
    <table class="App">
        <thead>
            <th>Name</th>
            <th>Description</th>
            <th>Operation</th>
        </thead>
        <tbody>
            <tr>
                <td>Fixed (Default)</td>
                <td>A fix for this ticket is checked into the tree and tested.</td>
                <td>Edit | Delete</td>
            </tr>
        </tbody>
    </table>

    <div class="Section">
        <h1>Create Resolution</h1>
        <% Html.BeginForm(); %>
            <% Html.RenderPartial("CreateEditResolutionForm"); %>
        <% Html.EndForm(); %>
    </div>

</asp:Content>
