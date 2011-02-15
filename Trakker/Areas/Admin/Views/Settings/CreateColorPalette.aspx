<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.master" Inherits="System.Web.Mvc.ViewPage<CreateEditColorPaletteModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="Section">
        <h2>Create Color Palette</h2>
        
        <% Html.RenderPartial("CreateEditColorPalette", Model); %>
    </div>

</asp:Content>
