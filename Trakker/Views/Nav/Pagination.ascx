<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Trakker.Helpers.Pagination>" %>

<div class="Pagination">

    <% if (Model.HasPreviousPage)
       { %>
         <%= Html.ActionLink( "�", MVC.Ticket.BrowseTickets(Model.PreviousPage))%>
    <% } else {%>
        <a>�</a>
    <% } %>

    <%for (int i = Model.Lowerbound; i <= Model.Upperbound; i++) { %>
    

        <% if (i == Model.Index)
           { %>
            <%= Html.ActionLink(i.ToString(), MVC.Ticket.BrowseTickets(i), new { @class = "Current" })%>
        <% } else { %>
           <%= Html.ActionLink(i.ToString(), MVC.Ticket.BrowseTickets(i))%>
        <% } %>
    <% } %>
    
    <% if (Model.HasNextPage){ %>
        <%= Html.ActionLink("�", MVC.Ticket.BrowseTickets(Model.NextPage))%>
    <% } else {%>
        <a>�</a>
    <% } %>
    
</div>

