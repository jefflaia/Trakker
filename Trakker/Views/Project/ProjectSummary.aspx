<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Basic.Master" Inherits="System.Web.Mvc.ViewPage<ProjectSummaryModel>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="BasicContent" runat="server">

    <h2><%= Model.Project.Name %>: <em><%= Model.Project.KeyName %></em></h2>
    
    <div id="ProjectContainer">
        <div class="Left">
            <div class="Description Section">
                <h3>Description</h3>
                <ul>
                    <li><p><span>Url:</span><a href="<%: Model.Project.Url %>"><%: Model.Project.Url %></a></p></li>
                    <li><p><span>Lead:</span><%: Model.Lead.FullName() %></p></li>
                    <li><p><span>Key:</span><%: Model.Project.KeyName %></p></li>
                </ul>
            </div>

            <div class="Issues Section">
                <h3>Tickets: Newest</h3>
                <ul>
                <% foreach (var ticket in Model.Tickets)
                   { %>
                    <li>
                        <p class="Left"><%= Html.ActionLink<TicketController>(c => c.TicketDetails(ticket.KeyName), ticket.KeyName) %> </p>
                        <p class="Right"><span>Created:</span> <%: ticket.Created %></p>
                        <p><%: ticket.Summary %></p>
                    </li>
                <% } %>
                </ul>
            </div>
        </div>

        <div class="Right">
        
        </div>
    </div>


</asp:Content>
