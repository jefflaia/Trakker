<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<LoginViewData>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <% using (Html.BeginForm(400)) { %>
    <h2>Login</h2>
        
        <%= Html.FormRow()
            .AddToLeft(Html.LabelFor(x => x.Email))
            .AddToRight(Html.TextBoxFor(x => x.Email)) %>

        <%= Html.FormRow()
            .AddToLeft(Html.LabelFor(x => x.Password))
            .AddToRight(Html.PasswordFor(x => x.Password)) %>
        
        <%= Html.FormRow()
            .AddToRight(Html.LoginButton("Login", new { }))%>  

    <% } %>

 
 <!--
     <textarea class="test" id="test"></textarea>
     		<script type="text/javascript">
		//<![CDATA[
     		    // Replace the <textarea id="editor1"> with an CKEditor instance.
     		    var editor = CKEDITOR.replace('test');
		//]]>
		</script>

        <%= Html.CKEditorTextArea("somename", "somevalue", new { }) %>
        -->

</asp:Content>
