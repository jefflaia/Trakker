<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MasterViewData>" %>
<ul>
    <li>
        <a href="">Projects</a>
        <ul class="UI-Shadow">
            <% if (Model.CurrentProject != null) { %>
                <li class="Heading">Current Project</li>
                <li><%= Html.ActionLink<ProjectController>(x => x.ProjectSummary(Model.CurrentProject.KeyName), Model.CurrentProject.Name)%></li>
                <li class="Break"></li>
            <% } %>
           
            <% if (Model.RecentProjects.Count > 0) { %>
                <li class="Heading">Recent Projects</li>
                <% foreach (var project in Model.RecentProjects) { %>
                    <li><%= Html.ActionLink<ProjectController>(x => x.ProjectSummary(project.KeyName), project.Name)%></li>
                <% } %>
            <% } %>
        </ul>
    </li>
    <li>
       <%= Html.ActionLink<TicketController>(x => x.TicketList(1), "Tickets") %>
        <ul class="UI-Shadow">
            <li><%= Html.ActionLink<TicketController>(x => x.CreateTicket(), "Create ticket") %></li>
            <li class="Break"></li>    
            <li class="Heading">Newest Tickets</li>   
            <% foreach (var ticket in Model.Tickets)
               { %>               
               <li><%= Html.ActionLink<TicketController>(X => X.TicketDetails(ticket.KeyName), Html.Exerpt(ticket.Summary, 30)) %></li>
            <% } %>
            <li class="Break"></li>
            <li><%= Html.ActionLink<TicketController>(x => x.TicketList(1), "View All") %></li>
        </ul>
    </li>
    <li>
        <a href="#">Administration</a>
        <ul class="UI-Shadow">
            <li><%= Html.RouteLink("Attributes", new { area = "Admin", controller = "Attribute", action = "Index"}) %></li>
            <li><%= Html.RouteLink("Management", new { area = "Admin", controller = "Management", action = "Index" }) %></li>
        </ul>
    </li> 
</ul>
