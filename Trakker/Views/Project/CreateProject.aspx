<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CreateProjectViewData>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% using (Html.BeginForm())
       {%>
            <h2>Create Project</h2>

            <%= Html.FormRow()
                .AddToLeft(Html.LabelFor(m => m.Name))
                .AddToRight(Html.TextBoxFor(m => m.Name))
                .AddToRight(Html.ValidationMessageFor(x => x.Name))
            %>

            <%= Html.FormRow()
                .AddToLeft(Html.LabelFor(m => m.Url))
                .AddToRight(Html.TextBoxFor(m => m.Url))
                .AddToRight(Html.ValidationMessageFor(x => x.Url))
                .AppendDescription("A url pertaining to this project.")
            %>

            <%= Html.FormRow()
                .AddToLeft(Html.LabelFor(m => m.KeyName))
                .AddToRight(Html.TextBoxFor(m => m.KeyName))
                .AddToRight(Html.ValidationMessageFor(x => x.KeyName))
                .AppendDescription("A unique key for this project.")
            %>

            <%= Html.FormRow()
                .AddToLeft(Html.LabelFor(m => m.Due))
                .AddToRight(Html.Telerik().DatePickerFor(m => m.Due))
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

    <% } %>

</asp:Content>
