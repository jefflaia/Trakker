<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Basic.Master" Inherits="System.Web.Mvc.ViewPage<TicketDetailsModel>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="BasicContent" runat="server">
    
 
    <div id="TicketDetails">
        <div class="Header">
            <img src="../../Content/Images/TestTicketIcon.png" />
            <p><%: Model.KeyName  %></p>
            <h1><%: Model.Summary %></h1>
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
                <li><label>Priority:</label>    <span><%= Model.Priority.Name%></span></li>
                <li><label>Category:</label>    <span><%= Model.Cateogory.Name%></span></li>
                <li><label>Status:</label>      <span><%= Model.Status.Name%></span></li>
                <li><label>Created:</label>     <span><%= Model.Created%></span></li>
                <li><label>DueDate:</label>     <span><%= Model.DueDate%></span></li>
                <li><label>Resoltuion:</label>  <span><%= Model.Resolution.Name %></span></li>
                <li><label>Status:</label>      <span><%= Model.IsClosed ? "Closed" : "Open" %></span></li>
            </ul>                         
        </div>
        
        <div class="People List SubSection">
            <h2>People</h2>

            <ul>
                <li><label>Assigned To:</label>     <span><%= Model.AssignedBy.Email %></span></li>
                <li><label>Created By:</label>      <span><%= Model.CreatedBy.Email %></span></li>
                <li><label>Assigned By:</label>     <span><%= Model.AssignedTo.Email %></span></li>
            </ul>        
        </div>

        <div class="Dates List SubSection">
            <h2>Dates</h2>
            <label>Created:</label>     <p class="Value"><%= Model.Created %></p>
            <label>Due Date:</label>    <p class="Value"><%= Model.DueDate %></p>
        </div>

        <div class="Desc SubSection">
            <h2>Description:</h2>
            <div><%= Model.Description%></div>
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
