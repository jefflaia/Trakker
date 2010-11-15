<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Basic.Master" Inherits="System.Web.Mvc.ViewPage<Trakker.ViewData.TicketData.CreateEditPriorityViewData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BasicContent" runat="server">

    <% using(Html.BeginForm()) { %>
        <h2>Create Priority</h2>
        <% Html.RenderPartial("CreateEditPriorityForm"); %>
    <% } %>

    <div id="Due" class="t-widget t-datepicker"><input value="" title="Due" name="Due" id="Due-input" class="t-input" autocomplete="off"><a title="Open the calendar" tabindex="-1" href="#" class="t-link t-icon t-icon-calendar">select date</a></div>

</asp:Content>
