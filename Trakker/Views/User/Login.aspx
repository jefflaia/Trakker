<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ViewWrapperViewData<MasterViewData,LoginViewData>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Login
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Login</h2>
    
    <% using (Html.BeginForm()) { %>
        
        <label for="Email">Email:</label>
        <%= Html.TextBox("Email", Model.View.Email) %>
        
        <label for="Password">Password:</label>
        <%= Html.Password("Password", Model.View.Password)%>

        <%= Html.Button("Login", "Login", HtmlButtonType.Submit) %>
    
    <% } %>

    <%
    
        Model.View.Table.Render();
     %>

     <textarea class="test" id="test"></textarea>
     		<script type="text/javascript">
		//<![CDATA[
     		    // Replace the <textarea id="editor1"> with an CKEditor instance.
     		    var editor = CKEDITOR.replace('test');
		//]]>
		</script>

</asp:Content>
