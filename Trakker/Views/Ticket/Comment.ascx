<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<Trakker.Data.Comment>>" %>

<ul>
    <% foreach(var comment in Model) { %>
        <li class="Comment">
            <div class="UserInfo">
    
                <p>Created: <%= comment.Created%></p>
                <p>Modified: <%= comment.Modified%></p>
            </div>
            <p class="Body"><%= comment.Body%></p>
        </li>
    <% } %>
</ul>

