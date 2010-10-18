using System;
using System.Data;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Trakker.Helpers.Icons;
using System.Reflection;
using Trakker.Helpers.Elements;
using System.Drawing;

namespace Trakker.Helpers
{
    public enum Relation 
    {
        Left,
        Right,
        Center,
        Single,
        Top,
        Bottom
    }

    public class SystemButtonBuilder : ISystemButtonBuilder
    {

        protected IIcon _icon;
        protected IElement _element;
        protected Relation _relation;

        protected const string ICON_CLASS_SUFFIX = "Icon";
        protected const string ICON_CLASS_PREFFIX = "Trakker.Helpers.Icons.";
        protected const string BASE_CSSCLASS = "UI-Button";

        public TagBuilder CreateButton(string innerText, string action, object attributes)
        {
            var tag = _element.Get();

            tag.MergeAttributes(new RouteValueDictionary(attributes));
            tag.MergeAttribute("href", action);

            tag.AddCssClass(BASE_CSSCLASS);
            tag.AddCssClass(GetRelationCss(_relation));

            tag.InnerHtml = string.Concat(BuildInnerHtml(innerText), _icon.Get());

            return tag;
        }

        public void SetIcon(IIcon icon)
        {
            _icon = icon;
        }

        public void SetElement(IElement element)
        {
            _element = element;
        }

        public void SetRelation(Relation relation)
        {
            _relation = relation;
        }

        protected string GetRelationCss(Relation relation)
        {
            switch (relation)
            {
                case Relation.Left:
                    return "UI-Border-Left";
                case Relation.Right:
                    return "UI-Border-Right";
                case Relation.Center:
                    return "UI-Border-Center";
                case Relation.Top:
                    return "UI-Border-Top";
                case Relation.Bottom:
                    return "UI-Border-Bottom";
                case Relation.Single:
                default:
                    return "UI-Border";
            }
        }

        protected string BuildInnerHtml(string innerText)
        {
            TagBuilder tag = new TagBuilder("span");
            tag.SetInnerText(innerText);

            return tag.ToString();
        }
    }
}