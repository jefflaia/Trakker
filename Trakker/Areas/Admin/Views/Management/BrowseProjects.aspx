<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.master" Inherits="System.Web.Mvc.ViewPage<BrowseProjectsModel>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="Section">
        <h1>Browse Projects</h1>
        <p>In the table below is a list of all the projects being managed by this system. Select a project to edit.</p>
        <p><%= Html.RouteLink("Create Project", "CreateProject") %></p>
    </div>

    <table class="Grid Indent">
        <thead>
            <tr>
                <th>Name</th>
                <th>Leader</th>
                <th>Key</th>
                <th>Due</th>
                <th>Created</th>
                <th>Operations</th>
            </tr>
        </thead>
        <tbody>
            <% foreach(var project in Model.Projects) { %>
                <tr>
                    <td><%= Html.RouteLink(project.Name, "ViewProject", new { keyName = project.KeyName.ToLower() })%></td>
                    <td><%= Model.Users[project.Lead].FullName() %></td>
                    <td><%= project.KeyName  %></td>
                    <td><%= project.Due  %></td>
                    <td><%= project.Created  %></td>
                    <td><%= Html.RouteLink("Edit", "EditProject", new { keyName = project.KeyName.ToLower() }) %></td>
                </tr>
            <% } %>        
        </tbody>
        
    </table>

</asp:Content>
