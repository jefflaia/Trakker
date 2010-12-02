<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.master" Inherits="System.Web.Mvc.ViewPage<Trakker.Areas.Admin.Models.ViewUserModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="Section">
        <h1>User: <em><%: Model.User.FullName() %></em></h1>
        <p><strong>Name:</strong> <%: Model.User.FullName() %></p>
        <p><strong>Email:</strong> <%: Model.User.Email %></p>
        <p><strong>Role:</strong> <%: Model.User.RoleId %></p>
        <p><strong>Created:</strong> <%: Model.User.Created %></p>
        <p><strong>Last Login:</strong> <%: Model.User.LastLogin %></p>
        <p><strong>Last Failed Login Attempt:</strong> <%: Model.User.LastFailedLoginAttempt %></p>
        <p><strong>Total Comments:</strong> <%: Model.User.TotalComments %></p>
    </div>

</asp:Content>
