using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Web.Routing;
using Trakker.Helpers.Icons;
using Trakker.Helpers.Elements;
using Trakker.Core.Forms;
using System.Web.Mvc.Html;
using System.Linq.Expressions;
using Trakker.Core;

namespace Trakker.Helpers
{

    public static class HtmlHelperExtentions
    {
        public static FormRow FormRow(this HtmlHelper helper)
        {
            return new FormRow();
        }

        public static string FormHR(this HtmlHelper helper)
        {
            TagBuilder tag = new TagBuilder("div");
            tag.AddCssClass("HorizontalRule");
            return tag.ToString();
        }

        public static string StyledSubmitButton(this HtmlHelper helper, string text, object attributes)
        {
            var input = new TagBuilder("input");
            input.MergeAttribute("type", "submit");
            input.MergeAttributes(new RouteValueDictionary(attributes));
            input.MergeAttribute("value", text);
            input.AddCssClass("UIButton");

            return input.ToString(TagRenderMode.SelfClosing);
        }
        /*
                public static string Link(this HtmlHelper helper, string fileName, string rel, object attributes)
                {
                    var link = new TagBuilder("link");
                    link.MergeAttribute("rel", rel);
                    link.MergeAttribute("type", "text/css");
                    link.MergeAttributes(new RouteValueDictionary(attributes));
                    link.MergeAttribute("href", "");

                    return link.ToString(TagRenderMode.SelfClosing);
                }
                */

        public static MvcForm BeginForm(this HtmlHelper htmlHelper, int width)
        {
            return BeginForm(htmlHelper, width, true);
        }

        public static MvcForm BeginForm(this HtmlHelper htmlHelper, int width, bool center)
        {
            object attrs = new
            {
                style = "width: " + width + "px;",
                @class = (center ? "Center" : "")
            };

            return htmlHelper.BeginForm(null, null, FormMethod.Post, new RouteValueDictionary(attrs));
        }

        public static string Exerpt(this HtmlHelper htmlHelper, string text, int length)
        {
            if (text.Length > length)
            {
                text = text.Substring(0, length).Trim() + "...";
            }

            return text;
        }
    }
}