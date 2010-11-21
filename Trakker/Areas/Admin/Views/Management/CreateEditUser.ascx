﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CreateEditUserModel>" %>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.FirstName))
    .AddToRight(Html.TextBoxFor(x => x.FirstName, Model.FirstName))
    .AddToRight(Html.ValidationMessageFor(m => m.FirstName)) %>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.LastName))
    .AddToRight(Html.TextBoxFor(x => x.LastName, Model.LastName))
    .AddToRight(Html.ValidationMessageFor(m => m.LastName)) %>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.Email))
    .AddToRight(Html.TextBoxFor(x => x.Email, Model.Email))
    .AddToRight(Html.ValidationMessageFor(m => m.Email)) %>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.Password))
    .AddToRight(Html.PasswordFor(x => x.Password, Model.Password))
    .AddToRight(Html.ValidationMessageFor(m => m.Password)) %>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.RePassword))
    .AddToRight(Html.PasswordFor(x => x.RePassword, Model.RePassword))
    .AddToRight(Html.ValidationMessageFor(m => m.RePassword)) %>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(x => x.RoleId))
    .AddToRight(Html.DropDownListFor(x => x.RoleId, new SelectList(Model.Roles, "RoleId", "Name", Model.RoleId )))
    .AddToRight(Html.ValidationMessageFor(m => m.RoleId))%>

<%= Html.FormRow()
    .AddToRight(Html.SaveButton("Save", null))%>