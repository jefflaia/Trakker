<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<Trakker.Infastructure.Streams.Activity.Model.ActivityGroupModel>>" %>
<div id="Stream">
    <ol>
    <% foreach (var group in Model) { %>
        <li>
            <span class="Date"><%: group.Created.ToString("D") %></span>
            <ol>
            <% foreach (var activity in group.Activities) { %>
                <li>
                    <img height="16" width="16" src="/Content/Images/TestTicketIcon.png">
                    <p>
                        <strong><%: activity.User.FullName() %></strong> commented on 
                        <strong><%: Html.ActionLink(activity.Ticket.KeyName, MVC.Ticket.TicketDetails(activity.Ticket.KeyName))%></strong> at <strong><%: activity.Created.ToShortTimeString() %></strong> saying:
                    </p>
                    <div>
                        <%: activity.Comment %>
                    </div>
                </li>
            <% } %>
            </ol>
        </li>
    <% } %>
    </ol>    
</div>