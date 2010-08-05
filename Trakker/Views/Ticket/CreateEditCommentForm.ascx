<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Trakker.ViewData.TicketData.CommentCreateEditViewData>" %>


    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p> 
                <label for="Body">Message here:</label>
                <%= Html.TextAreaFor(x => x.Comment.Body) %>
                <%= Html.ValidationMessageFor(x => x.Comment.Body) %>
            </p>
            
            <p>
                <%= Html.StyledSubmitButton("Save", null) %>
            </p>
        </fieldset>

    <% } %>


