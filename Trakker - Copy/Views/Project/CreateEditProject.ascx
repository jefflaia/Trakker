<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Trakker.ViewData.ProjectData.CreateEditProjectViewData>" %>

<% using (Html.BeginForm()) {%>
    <div class="Row">
        <label for="Name">Project Name:</label>
        <%= Html.TextBox("Name", Model.Project.Name)%>
    </div>

    <div class="Row">
        <label for="Key">Project Key:</label>
        <%= Html.TextBox("KeyName", Model.Project.KeyName)%>
    </div>

    <div class="Row">
        <label for="Due">Due Date:</label>
        <%= Html.TextBox("Due", Model.Project.Due)%>
    </div>

    <div class="Row">
        <label for="Lead">Project Lead:</label>
        <%= Html.DropDownList("Lead", new SelectList(Model.Users, "UserID", "Email", Model.Project.Lead))%>
    </div>

    <%= Html.SaveButton("Comment", Relation.Left, Icon.CreateComment, null) %>
    <%= Html.SaveButton("Edit", Relation.Center, Icon.EditTicket, null) %>
    <%= Html.SaveButton("Assign", Relation.Center, Icon.Assign, null) %>
    <%= Html.SaveButton("Assign To Me", Relation.Center, Icon.AssignToMe, null) %>
    <%= Html.SaveButton("Watch Issue", Relation.Center, Icon.WatchIssue, null) %>
    <%= Html.SaveButton("Save", Relation.Right, Icon.Save, null) %>


<% } %>
