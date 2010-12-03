<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Basic.Master" Inherits="System.Web.Mvc.ViewPage<CreateEditTicketModel>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="BasicContent" runat="server">

    <div class="Section">
        <h1>Create Ticket</h1>
        <% Html.BeginForm(); %>
            <% Html.RenderPartial("CreateEditTicketForm", Model); %>
        <% Html.EndForm(); %>
    </div>


</asp:Content>
