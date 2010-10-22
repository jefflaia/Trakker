<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Trakker.ViewData.TicketData.CreateEditViewData>" %>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.ProjectId))
        .AddToRight(Html.DropDownListFor(x => x.ProjectId, new SelectList(Model.Projects, "ProjectId", "Name")))
    .AddToRight(Html.ValidationMessageFor(x => x.ProjectId))%>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.Summary))
    .AddToRight(Html.TextBoxFor(x => x.Summary, new { style = "width: 450px;" }))
    .AddToRight(Html.ValidationMessageFor(x => x.Summary))%>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.AssignedToUserId))
    .AddToRight(Html.TextBoxFor(x => x.AssignedToUserId))
    .AddToRight(Html.ValidationMessageFor(x => x.AssignedToUserId)) %>

    <%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.PriorityId))
    .AddToRight(Html.DropDownListFor(x => x.PriorityId, new SelectList(Model.Priorities, "PriorityId", "Name")))
    .AddToRight(Html.ValidationMessageFor(x => x.PriorityId)) %>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.StatusId))
    .AddToRight(Html.DropDownListFor(x => x.StatusId, new SelectList(Model.Status, "StatusId", "Name")))
    .AddToRight(Html.ValidationMessageFor(x => x.StatusId)) %>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.CategoryId))
    .AddToRight(Html.DropDownListFor(x => x.CategoryId, new SelectList(Model.Categories, "CategoryId", "Name")))
    .AddToRight(Html.ValidationMessageFor(x => x.CategoryId)) %>



<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.DueDate))
    .AddToRight(Html.TextBoxFor(x => x.DueDate))
    .AddToRight(Html.ValidationMessageFor(x => x.DueDate)) %>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.Description))
    .AddToRight(Html.TextAreaFor(x => x.Description, new { style = "width: 450px; height: 70px;" }))
    .AddToRight(Html.ValidationMessageFor(x => x.Description))%>

<%= Html.FormRow()
    .AddToRight(Html.SaveButton("Save", new {})) %>



