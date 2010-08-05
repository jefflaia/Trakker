<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ViewWrapperViewData<MasterViewData,TicketListViewData>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>ticketList2</h2>
    <% Model.View.Pagination.Render(ViewContext); %>
    <table>
        <tr class="Header">
            <th>Key Name</th>
            <th>Summary</th>
            <th>Category</th>
            <th>Severity</th>
            <th>Priority</th>
            <th>Status</th>
            <th>Created By</th>
            <th>Assigned To</th>
            <th>Assigned By</th>
        </tr>
        <% foreach (var item in Model.View.Items)
           { %>
        <tr>
            <td><%= Html.Encode(item.KeyName) %></td>
            <td><%= Html.ActionLink<TicketController>(x => x.TicketDetails(item.KeyName), Html.Encode(item.Summary))%></td>
            <td><%= Html.Encode(Model.View.Categories[item.CategoryId].Name)%></td>
            <td >
                <span class="ColorBar" style="background-color: #<%= Model.View.Severities[item.SeverityId].HexColor %>;"></span>
                <%= Html.Encode(Model.View.Severities[item.SeverityId].Name)%>
            </td>
            <td >
                <span class="ColorBar" style="background-color: #<%= Model.View.Priorities[item.PriorityId].HexColor %>;"></span>
                <%= Html.Encode(Model.View.Priorities[item.PriorityId].Name)%>
            </td>
            <td><%= Html.Encode(Model.View.Status[item.StatusId].Name)%></td>
            <td><%= Html.Encode(Model.View.Users[item.CreatedByUserId].Email)%></td
            <td><%= Html.Encode(Model.View.Users[item.AssignedToUserId].Email)%></td>
            <td><%= Html.Encode(Model.View.Users[item.AssignedByUserId].Email)%></td>


        </tr>
       <%}%>
    </table>

    <% Model.View.Pagination.Render(ViewContext); %>

</asp:Content>