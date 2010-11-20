<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MasterViewData>" %>
<ul>
    <li>
        <a href="">Projects</a>
        <ul class="UI-Shadow">
            <% if (Model.CurrentProject != null) { %>
                <li class="Heading">Current Project</li>
                <li><%= Html.RouteLink(Model.CurrentProject.Name, "ProjectSummary", new { keyName = Model.CurrentProject.KeyName }) %></li>
                <li class="Break"></li>
            <% } %>
           
            <% if (Model.RecentProjects.Count > 0) { %>
                <li class="Heading">Recent Projects</li>
                <% foreach (var project in Model.RecentProjects) { %>
                    <li><%= Html.RouteLink(project.Name, "ProjectSummary", new { keyName = project.KeyName }) %></li>
                <% } %>
            <% } %>
        </ul>
    </li>
    <li>
       <%= Html.RouteLink("Tickets", "TicketList", new { index = 1 }) %>
        <ul class="UI-Shadow">
            <li><%= Html.RouteLink("Create Ticket", "CreateTicket") %></li>
            <li class="Break"></li>    
            <li class="Heading">Newest Tickets</li>   
            <% foreach (var ticket in Model.Tickets)
               { %>               
               <li><%= Html.RouteLink(Html.Exerpt(ticket.Summary, 30), "TicketDetails", new {keyName = ticket.KeyName}) %></li>
            <% } %>
            <li class="Break"></li>
            <li><%= Html.RouteLink("View All", "TicketList", new { index = 1 }) %></li>
        </ul>
    </li>
    <li>
        <a href="#">Administration</a>
        <ul class="UI-Shadow">
            <li><%= Html.RouteLink("Attributes", "AttributeIndex") %></li>
            <li><%= Html.RouteLink("Management", "ManagementIndex") %></li>
        </ul>
    </li> 
</ul>
