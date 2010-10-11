<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Trakker.ViewData.UserData.CreateEditUserViewData>" %>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.Email))
    .AddToRight(Html.TextBoxFor(x => x.Email, Model.Email))
    .AppendDescription("Your email address") %>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.Password))
    .AddToRight(Html.TextBoxFor(x => x.Password, Model.Password)) %>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.RePassword))
    .AddToRight(Html.TextBoxFor(x => x.RePassword, Model.RePassword)) %>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.Roles))
    .AddToRight(Html.DropDownListFor(x => x.RoleId, new SelectList(Model.Roles, "RoleId", "Name", Model.RoleId ))) %>

<%= Html.FormRow()
    .AddToRight(Html.SaveButton("Save", Relation.Single, Icon.Save, new { type = "submit" })) %>