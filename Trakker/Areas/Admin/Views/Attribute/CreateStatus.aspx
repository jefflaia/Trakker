<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.master" Inherits="System.Web.Mvc.ViewPage<CreateEditStatusModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.BeginForm(); %>
        <h2>Create Status</h2>

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

</asp:Content>
