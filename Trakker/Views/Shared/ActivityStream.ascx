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
                        <strong><%: activity.UserId %></strong> commented on 
                        <strong><%: activity.Created.ToString() %></strong> at <strong><%: activity.Created.ToShortTimeString() %></strong> saying:
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