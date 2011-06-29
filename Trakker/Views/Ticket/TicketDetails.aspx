<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Basic.Master" Inherits="System.Web.Mvc.ViewPage<TicketDetailsModel>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="BasicContent" runat="server">
    
 
    <div id="TicketDetails">
        <div class="Header">
            <img src="../../Content/Images/TestTicketIcon.png" />
            <p><%: Model.Ticket.KeyName%></p>
            <h1><%: Model.Ticket.Summary%></h1>
        </div>

        <div class="Buttons">
            <%= Html.LinkButton("Edit", Relation.Single, null, new { })%>

            <%= Html.LinkButton("Assign", Relation.Left, null, new { })%>
            <%= Html.LinkButton("Comment", Relation.Center, null, new { }) %>
            <%= Html.LinkButton("Resolve", Relation.Right, null, new { })%>

            <%= Html.LinkButton("Attach File", Relation.Left, null, new { })%>
            <%= Html.LinkButton("Attach Screenshot", Relation.Right, null, new { })%>
        </div>

        <div class="Details List SubSection">
            <h2>Details</h2>     
            
            <ul>
                <li><label>Priority:</label>    <span><%= Model.Ticket.Priority.Name %></span></li>
                <li><label>Category:</label>    <span><%= Model.Ticket.Type.Name %></span></li>
                <li><label>Status:</label>      <span><%= Model.Ticket.Status.Name %></span></li>
                <li><label>Created:</label>     <span><%= Model.Ticket.Created %></span></li>
                <li><label>Due Date:</label>     <span><%= Model.Ticket.DueDate.ToString()%></span></li>
                <li><label>Resoltuion:</label>  <span><%= Model.Ticket.Resolution.Name%></span></li>
                <li><label>Status:</label>      <span><%= Model.Ticket.IsClosed ? "Closed" : "Open"%></span></li>
            </ul>                         
        </div>
        
        <div class="People List SubSection">
            <h2>People</h2>

            <ul>
                <li><label>Assigned To:</label>     <span><%: Html.ActionLink(Model.Ticket.AssignedBy.FullName(), MVC.User.UserProfile(Model.Ticket.AssignedBy.Id))%></span></li>
                <li><label>Created By:</label>      <span><%: Html.ActionLink(Model.Ticket.CreatedBy.FullName(), MVC.User.UserProfile(Model.Ticket.CreatedBy.Id))%></span></li>
                <li><label>Assigned By:</label>     <span><%: Html.ActionLink(Model.Ticket.AssignedTo.FullName(), MVC.User.UserProfile(Model.Ticket.AssignedTo.Id))%></span></li>
            </ul>        
        </div>

        <div class="Dates List SubSection">
            <h2>Dates</h2>
            <ul>
            <li><label>Created:</label>     <span><%= Model.Ticket.Created %></span></li>
            <li><label>Due Date:</label>    <span><%= Model.Ticket.DueDate %></span></li>
            </ul>
        </div>

        <div class="Desc SubSection">
            <h2>Description:</h2>
            <div><%= Model.Ticket.Description%></div>
        </div>

        <div class="TimeTracking SubSection">
            <h2>Time Tracking</h2>
        </div>


        <!-- the tabs -->
        <ul class="Tabs">
	        <li><a href="#comments">Comments</a></li>
	        <li><a href="#history">History</a></li>
            <li><a href="#activity">Activity</a></li>
        </ul>

        <!-- tab "panes" -->
        <div class="Panes">
	        <div class="Comments">
                <% Html.RenderPartial(MVC.Ticket.Views.TicketDetailsCommentsTab, Model.Comments); %>
            </div>
	        <div>Second tab content</div>
	        <div>
                <% Html.RenderPartial(MVC.Shared.Views.ActivityStream, Model.ActivityGroups); %>
            </div
        </div>         
           
    </div>

    <script>
        $(document).ready(function () {
            $("ul.Tabs").tabs("div.Panes > div", { current: "Current" });
        });
    
    </script>
   
</asp:Content>
