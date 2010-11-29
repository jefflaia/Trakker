<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.master" Inherits="System.Web.Mvc.ViewPage<CreateEditTypeModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="Section">
        <h1>View Ticket Types</h1>
        <p>The table below shows the types of tickets that can be created by this system.</p>
        <p>Scroll down to create a ticket type.</p>
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
            <% foreach(var type in Model.Types) { %>
            <tr>
                <td><%: type.Name%></td>
                <td><%: type.Description%></td>
                <td>
                    <%: Html.RouteLink("Edit", "EditType", new { typeId = type.Id })%>
                 | Delete</td>
            <% } %>
            </tr>
        </tbody>
    </table>

    <div class="Section">
        <h1>Create Ticket Type</h1>
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
    </div>

</asp:Content>
