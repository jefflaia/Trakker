<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div class="SubNav Dropdown">
    <ul>
        <li><%= Html.RouteLink("Attributes", "AttributeIndex") %>
            <a href="#" class="Toggle">V</a>
            <ul class="UI-Shadow">
                <li><%= Html.RouteLink("Create Priority", "CreatePriority") %></li>
                <li><%= Html.RouteLink("Create Resolution", "CreateResolution") %></li>
                <li></li>
            </ul>
        </li>
        <li><%= Html.RouteLink("Management", "ManagementIndex") %>
            <a href="#" class="Toggle">V</a>
            <ul class="UI-Shadow">
                <li><%= Html.RouteLink("Users", "BrowseUsers")%></li>
                <li><%= Html.RouteLink("Create User", "CreateUser") %></li>
                <li><%= Html.RouteLink("Projects", "BrowseProjects")%></li>
                <li><%= Html.RouteLink("Create Project", "CreateProject") %></li>
            </ul>
        </li>
    </ul>
</div>

    