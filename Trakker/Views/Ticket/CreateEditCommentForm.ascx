<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CommentCreateEditModel>" %>



<%= Html.FormRow()
    .AddToLeft(Html.LabelFor(m => m.Comment.Body))
    .AddToRight(Html.TextAreaFor(x => x.Comment.Body))
    .AddToRight(Html.ValidationMessageFor(m => m.Comment.Body))
%>

<%= Html.FormRow()
    .AddToRight(Html.SaveButton("Save", null))
%>






