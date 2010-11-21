<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.master" Inherits="System.Web.Mvc.ViewPage<Trakker.Areas.Admin.Models.Management.AllProjectsModel>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>All Projects</h2>
    <table>
        <thead>
            <tr>
                <th>Name</th>
                <th>Leader</th>
                <th>Key</th>
                <th>Due</th>
                <th>Created</th>
            </tr>
        </thead>
        <tbody>
            <% foreach(var project in Model.Projects) { %>
                <tr>
                    <td><%= Html.RouteLink(project.Name, "EditProject", new { keyName = project.KeyName }) %></td>
                    <td><%= project.Lead  %></td>
                    <td><%= project.KeyName  %></td>
                    <td><%= project.Due  %></td>
                    <td><%= project.Created  %></td>
                </tr>
            <% } %>        
        </tbody>
        
    </table>

</asp:Content>
