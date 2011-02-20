<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MasterModel>" %>
<ul>
    <li>
        <% if (Model.HasCurrentProject) { %>
            <%= Html.ActionLink("Projects", MVC.Project.ProjectSummary(Model.CurrentProject.KeyName.ToLower()))%>
        <% } else { %>
             <a href="">Projects</a>
             <!-- add project browser here -->
        <% } %>
        <ul class="UI-Shadow">
            <% if (Model.CurrentProject != null) { %>
                <li class="Heading">Current Project</li>
                <li><%= Html.ActionLink(Model.CurrentProject.Name, MVC.Project.ProjectSummary(Model.CurrentProject.KeyName.ToLower()))%></li>
                <li class="Break"></li>
            <% } %>
           
            <% if (Model.RecentProjects.Count > 0) { %>
                <li class="Heading">Recent Projects</li>
                <% foreach (var project in Model.RecentProjects) { %>
                    <li><%= Html.ActionLink(project.Name, MVC.Project.ProjectSummary(project.KeyName.ToLower())) %></li>
                <% } %>
            <% } %>
        </ul>
    </li>
    <li>
       <%= Html.RouteLink("Tickets", MVC.Ticket.BrowseTickets(1)) %>
        <ul class="UI-Shadow">
            <li><%= Html.ActionLink("Create Ticket", MVC.Ticket.CreateTicket())%></li>
            <li class="Break"></li>    
            <li class="Heading">Newest Tickets</li>   
            <% foreach (var ticket in Model.Tickets)
               { %>               
               <li><%= Html.ActionLink(Html.Exerpt(ticket.Summary, 30), MVC.Ticket.TicketDetails(ticket.KeyName.ToLower())) %></li>
            <% } %>
            <li class="Break"></li>
            <li><%= Html.ActionLink("View All", MVC.Ticket.BrowseTickets(1)) %></li>
        </ul>
    </li>
    <li>
        <a href="#">Administration</a>
        <ul class="UI-Shadow">
            <li><%= Html.ActionLink("Attributes", MVC.Admin.Attribute.Index()) %></li>
            <li><%: Html.ActionLink("Management", MVC.Admin.Management.Index()) %></li>
            <li><%: Html.ActionLink("Settings", MVC.Admin.Settings.Index()) %></li>
        </ul>
    </li> 
</ul>
