<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Trakker.Areas.Admin.Models.Attribute.CreateEditPriorityModel>" %>

<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(m => m.Name))
    .AddToRight(Html.TextBoxFor(m => m.Name))
    .AddToRight(Html.ValidationMessageFor(x => x.Name))
 %>

 <%= Html.FormRow()
    .AddToLeft(Html.LabelFor(m => m.Description))
    .AddToRight(Html.TextAreaFor(m => m.Description))
    .AddToRight(Html.ValidationMessageFor(x => x.Description))
 %>

  <%= Html.FormRow()
    .AddToLeft(Html.LabelFor(m => m.HexColor))
    .AddToRight(Html.TextBoxFor(m => m.HexColor))
    .AddToRight(Html.ValidationMessageFor(x => x.HexColor))
 %>

  <%= Html.FormRow()
    .AddToRight(Html.SaveButton("Save", null))
 %>
