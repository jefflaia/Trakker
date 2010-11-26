<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CreateEditTicketModel>" %>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.ProjectId))
        .AddToRight(Html.DropDownListFor(x => x.ProjectId, new SelectList(Model.Projects, "Id", "Name")))
    .AddToRight(Html.ValidationMessageFor(x => x.ProjectId))%>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.Summary))
    .AddToRight(Html.TextBoxFor(x => x.Summary, new { style = "width: 450px;" }))
    .AddToRight(Html.ValidationMessageFor(x => x.Summary))%>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.AssignedToUserId))
    .AddToRight(Html.DropDownListFor(x => x.AssignedToUserId, Model.Users.ToSelectList("Id", "Email")))
    .AddToRight(Html.ValidationMessageFor(x => x.AssignedToUserId)) %>

    <%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.PriorityId))
    .AddToRight(Html.DropDownListFor(x => x.PriorityId, Model.Priorities.ToSelectList("Id", "Name")))
    .AddToRight(Html.ValidationMessageFor(x => x.PriorityId)) %>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.StatusId))
    .AddToRight(Html.DropDownListFor(x => x.StatusId, Model.Status.ToSelectList("Id", "Name")))
    .AddToRight(Html.ValidationMessageFor(x => x.StatusId)) %>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.CategoryId))
     .AddToRight(Html.DropDownListFor(x => x.CategoryId, Model.Categories.ToSelectList("Id", "Name")))
    .AddToRight(Html.ValidationMessageFor(x => x.CategoryId)) %>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.ResolutionId))
    .AddToRight(Html.DropDownListFor(x => x.ResolutionId, Model.Resolutions.ToSelectList("Id", "Name")))
    .AddToRight(Html.ValidationMessageFor(x => x.ResolutionId))%>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.DueDate))
        .AddToRight(
            Html.Telerik().DatePickerFor(x => x.DueDate)
                .Value(Model.DueDate)
                .ShowButton(true))
        .AddToRight(Html.ValidationMessageFor(x => x.DueDate)) %>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.Description))
    .AddToRight(Html.TextAreaFor(x => x.Description, new { style = "width: 450px; height: 70px;" }))
    .AddToRight(Html.ValidationMessageFor(x => x.Description))%>

<%= Html.FormRow()
    .AddToRight(Html.SaveButton("Save", new {})) %>



