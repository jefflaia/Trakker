<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Trakker.ViewData.TicketData.CreateEditViewData>" %>

<%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>
<% using (Html.BeginForm()) {%>
    <div class="Row">
        <label for="Summary">Summary:</label>
        <%= Html.TextBox("Summary", Model.Ticket.Summary) %>
        <%= Html.ValidationMessage("Summary", "*") %>
    </div>

    <div class="Row">
        <label for="PriorityId">Assign To:</label>
        <%= Html.DropDownList("AssignedTo", new SelectList(Model.Users, "UserID", "Email", Model.Ticket.AssignedToUserId))%>
        <%= Html.ValidationMessage("AssignedTo", "*") %>
    </div>

    <div class="Row">
        <label for="PriorityId">Priority:</label>
        <%= Html.DropDownList("PriorityId", new SelectList(Model.Priorities, "PriorityId", "Name", Model.Ticket.PriorityId))%>
        <%= Html.ValidationMessage("PriorityId", "*") %>
    </div>

    <div class="Row">
        <label for="StatusId">Status:</label>
        <%= Html.DropDownList("StatusId", new SelectList(Model.Status, "StatusId", "Name", Model.Ticket.StatusId))%>
        <%= Html.ValidationMessage("StatusId", "*") %>
    </div>

    <div class="Row">
        <label for="CategoryId">Category:</label>
        <%= Html.DropDownList("CategoryId", new SelectList(Model.Categories, "CategoryId", "Name", Model.Ticket.CategoryId))%>
        <%= Html.ValidationMessage("CategoryId", "*")%>
    </div>

    <div class="Row">
        <label for="DueDate">DueDate:</label>
        <%= Html.TextBox("DueDate", String.Format("{0:g}", Model.Ticket.DueDate))%>
        <%= Html.ValidationMessage("DueDate", "*") %>
    </div>

    <div class="Row">
        <label for="Description">Description:</label>
        <%= Html.CKEditorTextArea("Description", Model.Ticket.Description, new { })%>
        <%= Html.ValidationMessage("Description", "*") %>
    </div>

    <div class="Row">
       <%= Html.StyledSubmitButton("Save", null)%>
    </div>
<% } %>



