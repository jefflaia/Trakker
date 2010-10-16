<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TicketDetailsViewData>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
   
   <%= Html.SaveButton("Save", new {}) %>

    <div id="TicketDetails">
         <h2><%= Model.Summary%></h2>
        
        <div class="LeftContent">
            <h3 class="SubHeader">Details</h3>            
            <label>Priority:</label>    <p class="Value"><%= Model.Priority.Name%></p>
            <label>Category:</label>    <p class="Value"><%= Model.Cateogory.Name%></p>
            <label>Status:</label>      <p class="Value"><%= Model.Status.Name%></p>
            <label>Created:</label>     <p class="Value"><%= Model.Created%></p>
            <label>DueDate:</label>     <p class="Value"><%= Model.DueDate%></p>
            
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
    
      <%= Html.ActionLink<TicketController>(x => x.CreateComment(Model.KeyName), "Create Comment")%>
            <br />
            
            <% foreach (var item in Model.Comments)
            {
                item.Render(ViewContext);
            }       
            %>
        
    </div>
   
</asp:Content>
