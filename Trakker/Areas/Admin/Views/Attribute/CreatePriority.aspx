<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.master" Inherits="System.Web.Mvc.ViewPage<CreateEditPriorityModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="Section">
        <h1>View Ticket Priorities</h1>
        <p>The table below shows all the priorities used by this system.</p>
    </div>

    <table class="Grid Indent">
        <thead>
            <tr>
                <th>Name</th>
                <th>Description</th>
                <th>Hex Color</th>
                <th>Operation</th>
            </tr>
        </thead>
        <tbody>
            <% foreach(var priority in Model.Priorities) { %>
            <tr>
                <td><%: priority.Name %></td>
                <td><%: priority.Description %></td>
                <td><%: priority.HexColor %></td>
                <td>
                    <%= Html.RouteLink("Edit", "EditPriority", new { priorityId = priority.Id }) %>
                | Delete</td>
            <% } %>
            </tr>
        </tbody>
    </table>

    <div class="Section">
         <h1>Create Ticket Priority</h1>

        <% Html.BeginForm(); %>
            <% Html.RenderPartial("CreateEditPriorityForm"); %>
        <% Html.EndForm(); %>
    </div>

</asp:Content>
