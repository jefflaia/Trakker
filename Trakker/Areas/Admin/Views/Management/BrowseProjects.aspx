<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.master" Inherits="System.Web.Mvc.ViewPage<BrowseProjectsModel>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="Section">
        <h1>Browse Projects</h1>
        <p>In the table below is a list of all the projects being managed by this system. Select a project to edit.</p>
        <p><%= Html.RouteLink("Create Project", "CreateProject") %></p>
    </div>

    <table class="Indent">
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
                    <td><%= Model.Users[project.Lead].FullName() %></td>
                    <td><%= project.KeyName  %></td>
                    <td><%= project.Due  %></td>
                    <td><%= project.Created  %></td>
                </tr>
            <% } %>        
        </tbody>
        
    </table>

</asp:Content>
