﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.master" Inherits="System.Web.Mvc.ViewPage<EditUserModel>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.BeginForm(); %>
        <h2>Edit User: <%: Model.Email %></h2>
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
            .AddToLeft(Html.LabelFor(x => x.RoleId))
            .AddToRight(Html.DropDownListFor(x => x.RoleId, new SelectList(Model.Roles, "RoleId", "Name", Model.RoleId )))
            .AddToRight(Html.ValidationMessageFor(m => m.RoleId))%>

        <%= Html.FormRow()
            .AddToRight(Html.SaveButton("Save", null))%>
    <% Html.EndForm(); %>

</asp:Content>
