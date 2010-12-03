<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Basic.Master" Inherits="System.Web.Mvc.ViewPage<BrowseTicketsModel>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="BasicContent" runat="server">
    <h2>ticketList2</h2>
    <table class="Grid">
        <thead>
            <tr>
                <th>Key Name</th>
                <th>Summary</th>
                <th>Category</th>
                <th>Priority</th>
                <th>Status</th>
                <th>Created By</th>
                <th>Assigned To</th>
                <th>Assigned By</th>
            </tr>
        </thead>
        <tbody>
        <% foreach (var item in Model.Items) { %>
            <tr>
                <td><%= Html.Encode(item.KeyName) %></td>
                <td><%= Html.ActionLink<TicketController>(x => x.TicketDetails(item.KeyName), Html.Encode(item.Summary))%></td>
                <td><%= Html.Encode(Model.Categories[item.CategoryId].Name)%></td>
           
                <td >
                    <span class="ColorBar" style="background-color: #<%= Model.Priorities[item.PriorityId].HexColor %>;"></span>
                    <%= Html.Encode(Model.Priorities[item.PriorityId].Name)%>
                </td>
                <td><%= Html.Encode(Model.Status[item.StatusId].Name)%></td>
                <td><%= Html.Encode(Model.Users[item.CreatedByUserId].Email)%></td>
                <td><%= Html.Encode(Model.Users[item.AssignedToUserId].Email)%></td>
                <td><%= Html.Encode(Model.Users[item.AssignedByUserId].Email)%></td>


            </tr>
       <%}%>
       </tbody>
    </table>

    <% Html.RenderAction("Pagination", "Nav", new { count = Model.TotalTickets, page = Model.Page, pageSize = Model.PageSize }); %>

</asp:Content>