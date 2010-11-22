<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Trakker.Helpers.Pagination>" %>

<div class="Pagination">

    <% if (Model.HasPreviousPage)
       { %>
         <%= Html.ActionLink<TicketController>(x => x.BrowseTickets(Model.PreviousPage), "«")%>
    <% } else {%>
        <a>«</a>
    <% } %>

    <%for (int i = Model.Lowerbound; i <= Model.Upperbound; i++) { %>
    

        <% if (i == Model.Index)
           { %>
            <%= Html.ActionLink<TicketController>(x => x.BrowseTickets(i), i.ToString(), new { @class = "Current" })%>
        <% } else { %>
           <%= Html.ActionLink<TicketController>(x => x.BrowseTickets(i), i.ToString())%>
        <% } %>
    <% } %>
    
    <% if (Model.HasNextPage){ %>
        <%= Html.ActionLink<TicketController>(x => x.BrowseTickets(Model.NextPage), "»")%>
    <% } else {%>
        <a>»</a>
    <% } %>
    
</div>

