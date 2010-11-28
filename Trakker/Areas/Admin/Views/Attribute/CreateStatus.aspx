<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.master" Inherits="System.Web.Mvc.ViewPage<CreateEditStatusModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="Section">
        <h1>View Statuses</h1>
        <p>The table below shows the statuses used by this system.</p>
        <p>Scroll down to create a status.</p>
    </div>

    <table class="Indent">
        <thead>
            <tr>
                <th>Name</th>
                <th>Description</th>
                <th>Operation</th>
            </tr>
        </thead>
        <tbody>
            <% foreach(var status in Model.Statuses) { %>
            <tr>
                <td><%: status.Name%></td>
                <td><%: status.Description%></td>
                <td>Edit | Delete</td>
            <% } %>
            </tr>
        </tbody>
    </table>

    <div class="Section">
        <% Html.BeginForm(); %>
            <h1>Create Status</h1>

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
    </div>

</asp:Content>
