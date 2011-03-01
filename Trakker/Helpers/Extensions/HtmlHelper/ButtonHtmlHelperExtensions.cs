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

        public static string LinkButton(this HtmlHelper helper, string innerHtml, Relation relation, IIcon icon, object attributes)
        {
            return Link(helper, innerHtml, relation, icon, attributes);
        }

        public static string SaveButton(this HtmlHelper helper, string innerHtml, object attributes)
        {
            return Button(helper, innerHtml, Relation.Single, new SaveIcon(), attributes);
        }




        private static string Link(HtmlHelper helper, string innerHtml, Relation relation, IIcon icon, object attributes)
        {
            return ButtonBuilder(helper, innerHtml, new LinkElement(), relation, icon, attributes);
        }

        private static string Button(HtmlHelper helper, string innerHtml, Relation relation, IIcon icon, object attributes)
        {
            return ButtonBuilder(helper, innerHtml, new ButtonElement(), relation, icon, attributes);
        }

        private static string ButtonBuilder(HtmlHelper helper, string innerHtml, IElement element, Relation relation, IIcon icon, object attributes)
        {
            SystemButtonBuilder buttonBuilder = new SystemButtonBuilder();
            buttonBuilder.SetIcon(icon);
            buttonBuilder.SetElement(new ButtonElement());
            buttonBuilder.SetRelation(relation);

            return buttonBuilder.CreateButton(innerHtml, "", attributes).ToString();
        }
    }
}