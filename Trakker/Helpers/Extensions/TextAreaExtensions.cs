using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Web.Mvc.Resources;
using System.Web.Routing;
using System.Web.Mvc;

namespace Trakker.Helpers
{
    public static class TextAreaExtensions
    {
        public static string CKEditorTextArea(this HtmlHelper htmlHelper, string name, string value, object htmlAttributes)
        {
            MvcHtmlString html = System.Web.Mvc.Html.TextAreaExtensions.TextArea(htmlHelper, name, value, htmlAttributes);

            return string.Concat(html, "<script type=\"text/javascript\">CKEDITOR.replace( '" + name + "' );</script>");
        }
    }
}