<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Trakker.Areas.Admin.Models.CreateEditTypeModel>" %>
<% Html.BeginForm(); %>
            
    <%= Html.FormRow()
        .AddToLeft(Html.LabelFor(m => m.Name))
        .AddToRight(Html.TextBoxFor(m => m.Name))
        .AddToRight(Html.ValidationMessageFor(x => x.Name)) %>

    <%= Html.FormRow()
        .AddToLeft(Html.LabelFor(m => m.Description))
        .AddToRight(Html.TextAreaFor(m => m.Description))
        .AddToRight(Html.ValidationMessageFor(x => x.Description)) %>

    <%= Html.FormRow()
        .AddToRight(Html.SaveButton("Save", null)) %>

<% Html.EndForm(); %>