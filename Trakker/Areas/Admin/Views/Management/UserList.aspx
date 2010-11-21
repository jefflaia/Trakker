﻿    <%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.master" Inherits="System.Web.Mvc.ViewPage<Trakker.Areas.Admin.Models.Management.UserListModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Users</h2>
    <table>
        <thead>
            <tr>
                <th>Full Name</th>
                <th>Email</th>
                <th>Created</th>
                <th>Last Login</th>
                <th>Role</th>
            </tr>
        </thead>
        <tbody>
            <% foreach(var user in Model.Users) { %>
                <tr>
                    <td><%= Html.RouteLink(Html.Encode(user.FullName()), "EditUser", new { userId = user.UserId }) %></td>
                    <td><%: user.Email %></td>
                    <td><%: user.Created %></td>
                    <td><%: user.LastLogin %></td>
                    <td><%: Model.Roles[user.RoleId].Name %></td>
                </tr>
            <% } %>        
        </tbody>        
    </table>
</asp:Content>
