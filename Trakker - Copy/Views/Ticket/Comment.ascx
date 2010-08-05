<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Trakker.ViewData.TicketData.CommentViewData>" %>

<div class="Comment">
    <div class="UserInfo">
    
        <p>Created: <%= Model.Created%></p>
        <p>Modified: <%= Model.Modified%></p>
    </div>
    <p class="Body"><%= Model.Body%></p>
</div>


<br />
<br />
