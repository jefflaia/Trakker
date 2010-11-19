<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div class="SubNav Dropdown">
    <ul>
        <li><a href="">Attributes</a>
            <ul class="UI-Shadow" style="display: none;">
                <li><%= Html.RouteLink("Create Priority", "CreatePriority") %></li>
                <li><%= Html.RouteLink("Create Resolution", "CreateResolution") %></li>
                <li></li>
            </ul>
        </li>
        <li><a href="">Management</a>
            <ul class="UI-Shadow" style="display: none;">
                <li><%= Html.RouteLink("Create User", "CreateUser") %></li>
                <li><%= Html.RouteLink("Projects", "AllProjects") %></li>
                <li><%= Html.RouteLink("Create Project", "CreateProject") %></li>
            </ul>
        </li>
    </ul>
</div>

    