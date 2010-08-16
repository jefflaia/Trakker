<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ViewWrapperViewData<MasterViewData,Trakker.ViewData.UserData.CreateUserViewData>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	CreateUser
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<% using (Html.BeginForm())
   { %>
    <h2>CreateUser</h2>
    <%= Html.LabelFor(x => x.View.Email)%>
    <%= Html.TextBox("Email", Model.View.Email)%>

    <%= Html.LabelFor(x => x.View.Password)%>
    <%= Html.TextBox("Password", Model.View.Password)%>

    <%= Html.LabelFor(x => x.View.RePassword)%>
    <%= Html.TextBox("RePassword", Model.View.RePassword)%>

    <%= Html.SaveButton("Save", Relation.Single, Icon.Save, new { type = "submit" })%>
<% } %>
</asp:Content>
