<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div class="SubNav Dropdown">
    <ul>
        <li><%= Html.RouteLink("Attributes", "AttributeIndex") %>
            <ul class="UI-Shadow">
                <li><%= Html.RouteLink("Create Priority", "CreatePriority") %></li>
                <li><%= Html.RouteLink("Create Resolution", "CreateResolution") %></li>
                <li></li>
            </ul>
        </li>
        <li><%= Html.RouteLink("Management", "ManagementIndex") %>
            <ul class="UI-Shadow">
                <li><%= Html.RouteLink("Users", "UserList") %></li>
                <li><%= Html.RouteLink("Create User", "CreateUser") %></li>
                <li><%= Html.RouteLink("Projects", "AllProjects") %></li>
                <li><%= Html.RouteLink("Create Project", "CreateProject") %></li>
            </ul>
        </li>
    </ul>
</div>

    