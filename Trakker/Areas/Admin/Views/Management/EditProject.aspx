<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.master" Inherits="System.Web.Mvc.ViewPage<EditProjectModel>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="Section">
        <h1>Edit Project</h1>
        <% Html.BeginForm(); %>
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
                    .AddToLeft(Html.LabelFor(m => m.Due))
                    .AddToRight(Html.Telerik().DatePickerFor(m => m.Due))
                    .AddToRight(Html.ValidationMessageFor(x => x.Due))
                %>

                <%= Html.FormRow()
                    .AddToLeft(Html.LabelFor(m => m.Lead))
                    .AddToRight(Html.DropDownListFor(m => m.Lead, Model.Users.ToSelectList("Id", "Email")))
                    .AddToRight(Html.ValidationMessageFor(x => x.Lead))
                %>

            <%= Html.FormRow()
                .AddToLeft(Html.LabelFor(m => m.ColorPaletteId))
                .AddToRight(Html.DropDownListFor(m => m.ColorPaletteId, Model.ColorPalettes.ToSelectList("Id", "Name")))
                .AddToRight(Html.ValidationMessageFor(x => x.ColorPaletteId))
            %>

                <%= Html.FormRow()
                    .AddToRight(Html.SaveButton("Save", null))
                %>
        <% Html.EndForm(); %>
    </div>
</asp:Content>
