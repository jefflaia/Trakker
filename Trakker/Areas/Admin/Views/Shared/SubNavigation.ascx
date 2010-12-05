<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div class="SubNav Dropdown">
    <ul>
        <li><%= Html.ActionLink("Attributes", MVC.Admin.Attribute.Index()) %>
            <ul class="UI-Shadow">
                <li><%= Html.ActionLink("Types", MVC.Admin.Attribute.CreateType()) %></li>
                <li><%= Html.ActionLink("Priorities", MVC.Admin.Attribute.CreatePriority()) %></li>
                <li><%= Html.ActionLink("Resolutions", MVC.Admin.Attribute.CreateResolution()) %></li>
                <li><%= Html.ActionLink("Statuses", MVC.Admin.Attribute.CreateStatus()) %></li>
            </ul>
        </li>
        <li><%= Html.RouteLink("Management", MVC.Admin.Management.Index()) %>
            <ul class="UI-Shadow">
                <li><%= Html.ActionLink("Users", MVC.Admin.Management.CreateUser()) %></li>
                <li><%= Html.ActionLink("Projects", MVC.Admin.Management.CreateProject()) %></li>
            </ul>
        </li>
    </ul>
</div>

    