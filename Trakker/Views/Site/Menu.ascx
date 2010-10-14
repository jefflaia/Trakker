<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MenuViewData>" %>
<ul>
    <li>
        <%= Html.ActionLink<ProjectController>(x => x.AllProjects(), "Projects") %>
        <ul class="UI-Shadow">
            <% if (Model.CurrentProject != null) { %>
                <li class="Heading">Current Project</li>
                <li><%= Html.ActionLink<ProjectController>(x => x.ProjectSummary(Model.CurrentProject.KeyName), Model.CurrentProject.Name)%></li>
                <li class="Break"></li>
            <% } %>
           
            <% if (Model.Projects.Count > 0) { %>
                <li class="Heading">Recent Projects</li>
                <% foreach (var project in Model.Projects) { %>
                    <li><%= Html.ActionLink<ProjectController>(x => x.ProjectSummary(project.KeyName), project.Name)%></li>
                <% } %>
            <% } %>
            <li class="Break"></li>
            <li><%= Html.ActionLink<ProjectController>(x => x.AllProjects(), "View All") %></li>
        </ul>
    </li>
    <li>
       <%= Html.ActionLink<TicketController>(x => x.TicketList(1), "Tickets") %>
        <ul class="UI-Shadow">
            <li><%= Html.ActionLink<TicketController>(x => x.CreateTicket(), "New ticket") %></li>
            <li class="Break"></li>    
            <li class="Heading">Newest Tickets</li>   
            <% foreach (var ticket in Model.Tickets)
               { %>               
               <li><%= Html.ActionLink<TicketController>(X => X.TicketDetails(ticket.KeyName), ticket.Summary) %></li>
            <% } %>
            <li class="Break"></li>
            <li><%= Html.ActionLink<TicketController>(x => x.TicketList(1), "View All") %></li>
        </ul>
    </li>
    <li>
        <a href="#">Administration</a>
        <ul class="UI-SHadow">
            <li><a href="#"><%= Html.ActionLink<UserController>(x => x.CreateUser(), "Create User") %></a></li>
            <li><a href="#">Edit User</a></li>
        </ul>
    </li> 
</ul>
