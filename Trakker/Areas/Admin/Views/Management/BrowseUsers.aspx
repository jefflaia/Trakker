    <%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.master" Inherits="System.Web.Mvc.ViewPage<BrowseUsersModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="Section">
        <h1>Browse Users</h1>
        <p>In the table below is all the users for this system.</p>
        <p><%= Html.RouteLink("Create User", "CreateUser") %></p>
    </div>

    <table class="Grid Indent">
        <thead>
            <tr>
                <th>Full Name</th>
                <th>Email</th>
                <th>Created</th>
                <th>Last Login</th>
                <th>Role</th>
                <th>Operation</th>
            </tr>
        </thead>
        <tbody>
            <% foreach(var user in Model.Users) { %>
                <tr>
                    <td>
                        <%: Html.RouteLink(user.FullName(), "ViewUser", new { userId = user.Id })%>
                    </td>
                    <td><%: user.Email %></td>
                    <td><%: user.Created %></td>
                    <td><%: user.LastLogin %></td>
                    <td><%: Model.Roles[user.RoleId].Name %></td>
                    <td>
                        <%= Html.RouteLink("Edit", "EditUser", new { userId = user.Id }) %> |
                        <%: Html.RouteLink("Change Password", "EditUserPassword", new { userId = user.Id }) %>
                     </td>
                </tr>
            <% } %>        
        </tbody>        
    </table>
</asp:Content>
