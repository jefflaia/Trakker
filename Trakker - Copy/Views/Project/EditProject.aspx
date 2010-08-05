<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ViewWrapperViewData<MasterViewData,CreateEditProjectViewData>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	CreateProject
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit Project: <%= Model.View.Project.Name %></h2>

    <% Html.RenderPartial("CreateEditProject", Model.View); %>

</asp:Content>
