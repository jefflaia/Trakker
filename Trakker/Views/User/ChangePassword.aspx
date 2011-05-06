<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Basic.Master" Inherits="System.Web.Mvc.ViewPage<Trakker.Models.ChangePasswordModel>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="BasicContent" runat="server">
    <div class="Section">
        <h1>Change Password for: <em><%: Model.User.FullName() %></em></h1>

        <% Html.BeginForm(); %>
            <%= Html.FormRow()
                .AddToLeft(Html.LabelFor(x => x.CurrentPassword))
                .AddToRight(Html.PasswordFor(x => x.CurrentPassword, Model.CurrentPassword))
                .AddToRight(Html.ValidationMessageFor(m => m.CurrentPassword))%>

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
    </div>

</asp:Content>
