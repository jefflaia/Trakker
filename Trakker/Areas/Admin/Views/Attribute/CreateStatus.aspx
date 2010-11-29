<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.master" Inherits="System.Web.Mvc.ViewPage<CreateEditStatusModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="Section">
        <h1>View Ticket Statuses</h1>
        <p>The table below shows the statuses used by this system.</p>
        <p>Scroll down to create a status.</p>
    </div>

    <table class="Indent">
        <thead>
            <tr>
                <th>Name</th>
                <th>Description</th>
                <th>Operation</th>
            </tr>
        </thead>
        <tbody>
            <% foreach(var status in Model.Statuses) { %>
            <tr>
                <td><%: status.Name%></td>
                <td><%: status.Description%></td>
                <td>
                    <%: Html.RouteLink("Edit", "EditStatus", new { statusId = status.Id }) %>
                 | Delete</td>
            <% } %>
            </tr>
        </tbody>
    </table>

    <div class="Section">
        <h1>Create Ticket Status</h1>

        <% Html.BeginForm(); %>
            <% Html.RenderPartial("CreateEditStatusForm", Model); %>
        <% Html.EndForm(); %>
    </div>

</asp:Content>
