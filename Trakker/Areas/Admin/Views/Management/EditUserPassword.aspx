<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.master" Inherits="System.Web.Mvc.ViewPage<Trakker.Areas.Admin.Models.EditUserPasswordModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.BeginForm(); %>
        <h2>Edit Password For: <%: Model.User.FullName() %></h2>

        <%= Html.FormRow()
            .AddToLeft(Html.LabelFor(x => x.Password))
            .AddToRight(Html.PasswordFor(x => x.Password, Model.Password))
            .AddToRight(Html.ValidationMessageFor(m => m.Password)) %>

        <%= Html.FormRow()
            .AddToLeft(Html.LabelFor(x => x.RePassword))
            .AddToRight(Html.PasswordFor(x => x.RePassword, Model.RePassword))
            .AddToRight(Html.ValidationMessageFor(m => m.RePassword)) %>
     
        <%= Html.FormRow()
            .AddToRight(Html.SaveButton("Save", null))%>

    <% Html.EndForm(); %>

</asp:Content>
