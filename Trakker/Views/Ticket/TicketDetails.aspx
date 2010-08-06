<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ViewWrapperViewData<MasterViewData,TicketDetailsViewData>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Model.View.Summary %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
   
   <%= Html.SaveButton("Save", Relation.Single, Icon.Save, new { }) %>

    <div id="TicketDetails">
         <h2><%= Model.View.Summary%></h2>
        
        <div class="LeftContent">
            <h3 class="SubHeader">Details</h3>            
            <label>Priority:</label>    <p class="Value"><%= Model.View.Priority.Name%></p>
            <label>Category:</label>    <p class="Value"><%= Model.View.Cateogory.Name%></p>
            <label>Status:</label>      <p class="Value"><%= Model.View.Status.Name%></p>
            <label>Severity:</label>    <p class="Value"><%= Model.View.Severity.Name%></p>
            <label>Created:</label>     <p class="Value"><%= Model.View.Created%></p>
            <label>DueDate:</label>     <p class="Value"><%= Model.View.DueDate%></p>
            
            <h3 class="SubHeader">Description:</h3>
            <p class="Description"><%= Model.View.Description%></p>
        
        </div>
        
        
        <div class="RightContent">
            <h3 class="SubHeader">People</h3>
            <label>Assigned To:</label>     <p class="Value"><%= Model.View.AssignedBy.Email %></p>
            <label>Created By:</label>      <p class="Value"><%= Model.View.CreatedBy.Email %></p>
            <label>Assigned By:</label>     <p class="Value"><%= Model.View.AssignedTo.Email %></p>
            
            <h3 class="SubHeader">Dates</h3>
            <label>Created:</label>     <p class="Value"><%= Model.View.Created %></p>
            <label>Due Date:</label>    <p class="Value"><%= Model.View.DueDate %></p>
        </div>
    
      <%= Html.ActionLink<TicketController>(x => x.CreateComment(Model.View.KeyName), "Create Comment")%>
            <br />
            
            <% foreach (var item in Model.View.Comments)
            {
                item.Render(ViewContext);
            }       
            %>
        
    </div>
   
</asp:Content>
