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
    .AddToRight(Html.DropDownListFor(x => x.AssignedToUserId, Model.Users.ToSelectList("UserId", "Email")))
    .AddToRight(Html.ValidationMessageFor(x => x.AssignedToUserId)) %>

    <%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.PriorityId))
    .AddToRight(Html.DropDownListFor(x => x.PriorityId, Model.Priorities.ToSelectList("PriorityId", "Name")))
    .AddToRight(Html.ValidationMessageFor(x => x.PriorityId)) %>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.StatusId))
    .AddToRight(Html.DropDownListFor(x => x.StatusId, Model.Status.ToSelectList("StatusId", "Name")))
    .AddToRight(Html.ValidationMessageFor(x => x.StatusId)) %>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.CategoryId))
     .AddToRight(Html.DropDownListFor(x => x.CategoryId, Model.Categories.ToSelectList("CategoryId", "Name")))
    .AddToRight(Html.ValidationMessageFor(x => x.CategoryId)) %>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.ResolutionId))
    .AddToRight(Html.DropDownListFor(x => x.ResolutionId, Model.Resolutions.ToSelectList("ResolutionId", "Name")))
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



