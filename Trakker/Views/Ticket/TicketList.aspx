<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TicketListViewData>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>ticketList2</h2>
    <table>
        <tr class="Header">
            <th>Key Name</th>
            <th>Summary</th>
            <th>Category</th>
            <th>Priority</th>
            <th>Status</th>
            <th>Created By</th>
            <th>Assigned To</th>
            <th>Assigned By</th>
        </tr>
        <% foreach (var item in Model.Items)
           { %>
        <tr>
            <td><%= Html.Encode(item.KeyName) %></td>
            <td><%= Html.ActionLink<TicketController>(x => x.TicketDetails(item.KeyName), Html.Encode(item.Summary))%></td>
            <td><%= Html.Encode(Model.Categories[item.CategoryId].Name)%></td>
           
            <td >
                <span class="ColorBar" style="background-color: #<%= Model.Priorities[item.PriorityId].HexColor %>;"></span>
                <%= Html.Encode(Model.Priorities[item.PriorityId].Name)%>
            </td>
            <td><%= Html.Encode(Model.Status[item.StatusId].Name)%></td>
            <td><%= Html.Encode(Model.Users[item.CreatedByUserId].Email)%></td
            <td><%= Html.Encode(Model.Users[item.AssignedToUserId].Email)%></td>
            <td><%= Html.Encode(Model.Users[item.AssignedByUserId].Email)%></td>


        </tr>
       <%}%>
    </table>

    <% Html.RenderAction<NavController>(c => c.ticketListPagination(Model.TotalTickets, Model.Page, Model.PageSize)); %>

</asp:Content>