<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Basic.Master" Inherits="System.Web.Mvc.ViewPage<TicketDetailsModel>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="BasicContent" runat="server">
    
   
   <%= Html.SaveButton("Save", new {}) %>
   <%= Html.LinkButton("Comment", Relation.Single, null, new { })%>

    <div id="TicketDetails">
         <h2><%= Model.Summary%></h2>
        
        <div class="LeftContent">
            <h3 class="SubHeader">Details</h3>            
            <label>Priority:</label>    <p class="Value"><%= Model.Priority.Name%></p>
            <label>Category:</label>    <p class="Value"><%= Model.Cateogory.Name%></p>
            <label>Status:</label>      <p class="Value"><%= Model.Status.Name%></p>
            <label>Created:</label>     <p class="Value"><%= Model.Created%></p>
            <label>DueDate:</label>     <p class="Value"><%= Model.DueDate%></p>
            <label>Resoltuion:</label>     <p class="Value"><%= Model.Resolution.Name %></p>
            <label>Status:</label><p><%= Model.IsClosed ? "Closed" : "Open" %></p>

            <h3 class="SubHeader">Description:</h3>
            <p class="Description"><%= Model.Description%></p>
        
        </div>
        
        
        <div class="RightContent">
            <h3 class="SubHeader">People</h3>
            <label>Assigned To:</label>     <p class="Value"><%= Model.AssignedBy.Email %></p>
            <label>Created By:</label>      <p class="Value"><%= Model.CreatedBy.Email %></p>
            <label>Assigned By:</label>     <p class="Value"><%= Model.AssignedTo.Email %></p>
            
            <h3 class="SubHeader">Dates</h3>
            <label>Created:</label>     <p class="Value"><%= Model.Created %></p>
            <label>Due Date:</label>    <p class="Value"><%= Model.DueDate %></p>
            
        </div>
        <!-- the tabs -->
        <ul class="Tabs">
	        <li><a href="#">All</a></li>
	        <li><a href="#">Comments</a></li>
	        <li><a href="#">History</a></li>
        </ul>

        <!-- tab "panes" -->
        <div class="Panes">
	        <div>
                <% foreach (var comment in Model.Comments) { %>
                    <% Html.RenderPartial(MVC.Ticket.Views.Comment, Model.Comments); %>
                <% } %>
            </div>
	        <div>Second tab content</div>
	        <div>Third tab content</div>
        </div>


    
      <%= Html.ActionLink<TicketController>(x => x.CreateComment(Model.KeyName), "Create Comment")%>
            <br />
            <%: Model.Comments.Count %>
            
            
        
    </div>

    <script>
        // perform JavaScript after the document is scriptable.
        $(document).ready(function () {
            // setup ul.tabs to work as tabs for each div directly under div.panes
            $("ul.Tabs").tabs("div.Panes > div", { current: "Current" });
        });
    
    </script>
   
</asp:Content>
