<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Basic.Master" Inherits="System.Web.Mvc.ViewPage<AllProjectsViewData>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="BasicContent" runat="server">

    <h2>All Projects</h2>
    <table>
        <thead>
            <tr class="Header">
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
                    <td><%= Html.ActionLink<ProjectController>(x=>x.EditProject(project.KeyName), project.Name)  %></td>
                    <td><%= project.Lead  %></td>
                    <td><%= project.KeyName  %></td>
                    <td><%= project.Due  %></td>
                    <td><%= project.Created  %></td>
                </tr>
            <% } %>        
        </tbody>
        
    </table>

</asp:Content>
