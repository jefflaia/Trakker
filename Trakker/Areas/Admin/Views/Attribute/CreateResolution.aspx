﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.master" Inherits="System.Web.Mvc.ViewPage<CreateEditResolutionModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="Section">
        <h1>View Resolutions</h1>
        <p>The table below shows the resolutions used by this system.</p>
        <p>Scroll down to create a resolution.</p>
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
            <% foreach(var resolution in Model.Resolutions) { %>
            <tr>
                <td><%: resolution.Name %></td>
                <td><%: resolution.Description %></td>
                <td>
                    <%: Html.RouteLink("Edit", "EditResolution", new { resolutionId = resolution.Id }) %>
                 | Delete</td>
            <% } %>
            </tr>
        </tbody>
    </table>

    <div class="Section">
        <h1>Create Resolution</h1>
        <% Html.BeginForm(); %>
            <% Html.RenderPartial("CreateEditResolutionForm"); %>
        <% Html.EndForm(); %>
    </div>

</asp:Content>
