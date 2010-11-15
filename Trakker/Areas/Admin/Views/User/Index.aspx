<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">

    
    <style>
        ul.SideNav{ float:left; display:block; position:relative; list-style-type:none; margin:0; padding:0; z-index: 5; margin-top: 20px; padding-top: 1px; }
        ul.SideNav li {border: 1px solid #bbb; display: block; background-color: #eee; margin: -1px -1px 0px 0px; padding: 3px 10px; }
        ul.SideNav li.Current{background-color: White; margin-left: -10px; border-right: none; min-width: 120px; font-weight: bold;}
        
       div.AdminContent { overflow-x: auto; background-color:#FFFFFF; border:1px solid #BBBBBB; min-height: 600px; position: relative; }
    </style>

    <div>
        <h1>Attributes</h1>
    </div>
    <ul class="SideNav">
        <li>Categories</li>
        <li class="Current">Resolutions</li>
        <li>Status</li>
        <li>Priorities</li>
    </ul>
    <div class="AdminContent">
        sa;ldka;slkdals;
    </div>
</asp:Content>
