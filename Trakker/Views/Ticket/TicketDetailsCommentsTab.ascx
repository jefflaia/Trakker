<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<Trakker.Data.Comment>>" %>

<ul>
    <% foreach(var comment in Model) { %>
        <li class="Comment">
            <img src="../../Content/Images/TestTicketIcon.png" width="16" height="16" />
            <p><a href="#"><strong><%: comment.UserId %></strong></a> commented on <strong><%: comment.Created.Date.ToShortDateString() %></strong> at <strong><%: comment.Created.TimeOfDay %></strong> saying:</p>
            <div><%: comment.Body%></div>
        </li>
    <% } %>

    <%= Html.LinkButton("Comment", Relation.Single, null, new { })%>
</ul>

