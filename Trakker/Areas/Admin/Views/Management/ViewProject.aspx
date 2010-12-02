<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.master" Inherits="System.Web.Mvc.ViewPage<Trakker.Areas.Admin.Models.ViewProjectModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="Section">
        <h1>Project: <em><%: Model.Project.Name %></em></h1>
        <p><strong>Key:</strong> <%: Model.Project.KeyName %></p>
        <p><strong>Lead:</strong> <%: Html.RouteLink(Model.User.FullName(), "ViewUser", new { userId = Model.User.Id }) %></p>
        <p><strong>Url:</strong> <%: Model.Project.Url %></p>
        <p><strong>Created:</strong> <%: Model.Project.Created %></p>
        <p><strong>Due:</strong> <%: Model.Project.Due %></p>
        <p><%: Html.RouteLink("Edit",  "EditProject", new { keyName = Model.Project.KeyName.ToLower() }) %></p>
    </div>
    
</asp:Content>
