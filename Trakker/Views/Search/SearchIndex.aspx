<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Basic.Master" Inherits="System.Web.Mvc.ViewPage<Trakker.Models.Search.SearchIndexModel>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="BasicContent" runat="server">

    <h2>SearchIndex</h2>

    <ul>
        <% foreach (var ticket in Model.Tickets)
           { %>
            <li><%: ticket.Summary %></li>    
        <% } %>
    </ul>

</asp:Content>
