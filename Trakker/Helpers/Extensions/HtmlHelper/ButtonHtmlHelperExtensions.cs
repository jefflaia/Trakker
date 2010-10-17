using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trakker.Helpers.Elements;
using Trakker.Helpers.Icons;

namespace Trakker.Helpers
{
    public static class ButtonHtmlHelperExtensions
    {

        public static string LoginButton(this HtmlHelper helper, string innerHtml, object attributes)
        {
            return Button(helper, innerHtml, Relation.Single, new LoginIcon(), attributes);
        }

        public static string SaveButton(this HtmlHelper helper, string innerHtml, object attributes)
        {
            return Button(helper, innerHtml, Relation.Single, new SaveIcon(), attributes);
        }

        private static string Button(this HtmlHelper helper, string innerHtml, Relation relation, IIcon icon, object attributes)
        {
            SystemButtonBuilder buttonBuilder = new SystemButtonBuilder();
            buttonBuilder.SetIcon(icon);
            buttonBuilder.SetElement(new ButtonElement());
            buttonBuilder.SetRelation(relation);

            return buttonBuilder.CreateButton(innerHtml, "", attributes).ToString();
        }
    }
}