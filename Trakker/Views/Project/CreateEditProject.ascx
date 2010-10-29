<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Trakker.ViewData.ProjectData.CreateEditProjectViewData>" %>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(m => m.Name))
    .AddToRight(Html.TextBoxFor(m => m.Name))
    .AddToRight(Html.ValidationMessageFor(x => x.Name))
%>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(m => m.KeyName))
    .AddToRight(Html.TextBoxFor(m => m.KeyName))
    .AddToRight(Html.ValidationMessageFor(x => x.KeyName))
%>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(m => m.Due))
    .AddToRight(Html.TextBoxFor(m => m.Due))
    .AddToRight(Html.ValidationMessageFor(x => x.Due))
%>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(m => m.Lead))
    .AddToRight(Html.DropDownListFor(m => m.Lead, Model.Users.ToSelectList("UserId", "Email")))
    .AddToRight(Html.ValidationMessageFor(x => x.Lead))
%>

<%= Html.FormRow()
    .AddToRight(Html.SaveButton("Save", null))

%>
