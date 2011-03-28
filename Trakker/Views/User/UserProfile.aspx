<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Basic.Master" Inherits="System.Web.Mvc.ViewPage<Trakker.Models.UserProfileModel>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="BasicContent" runat="server">
    <div id="UserProfile">
        <div class="Header">
            <img src="../../Content/Images/TestTicketIcon.png" />
            <h1><%: Model.User.FullName() %></h1>
        </div>

        <div class="Left">
            <div class="Details SubSection">
                <h2>Details</h2>
                <ul>
                    <li><label>Avatar:</label>      <span><a href="#">Edit</a></span></li>
                    <li><label>Name:</label>        <span><%: Model.User.FullName() %></span></li>
                    <li><label>Username:</label>    <span><%: Model.User.Email %></span></li>
                    <li><label>Password:</label>    <span><a href="#">Change Password</a></span></li>
                    <li><label>Groups:</label>      <span></span>
                        <ul>
                            <li>Admin</li>
                            <li>User</li>
                       </ul>
                    </li>
            
                </ul>
            </div>

            <div class="Preferences SubSection">
                <h2>Preferences</h2>
            </div>
        </div>

        <div class="Right">
            <div class="Activity SubSection">
                <h2>Activity</h2>
                <% Html.RenderPartial(MVC.Shared.Views.ActivityStream, Model.ActivityStreamGroups); %>
            </div>
        </div>

        
    </div>

</asp:Content>
