﻿
namespace Trakker.Infastructure.UI
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;
    using System.Text;
    using System.Web.Routing;

    public class HtmlTag : IHtmlNode
    {
        private readonly TagBuilder _tagBuilder;

        public HtmlTag(string tagName)
            : this(tagName, TagRenderMode.Normal)
        {
        }

        public HtmlTag(string tagName, TagRenderMode renderMode)
        {
            _tagBuilder = new TagBuilder(tagName);
            Children = new List<IHtmlNode>();
            RenderMode = renderMode;
        }

        private Action TemplateCallback { get; set; }

        public TagRenderMode RenderMode { get; private set; }

        public string TagName
        {
            get
            {
                return _tagBuilder.TagName;
            }
        }

        public IDictionary<string, string> Attributes()
        {
            return _tagBuilder.Attributes;
        }

        public string Attribute(string key)
        {
            return Attributes()[key];
        }

        public IList<IHtmlNode> Children
        {
            get;
            private set;
        }

        public override string ToString()
        {
            using (StringWriter output = new StringWriter(CultureInfo.CurrentCulture))
            {
                WriteTo(output);

                return output.GetStringBuilder().ToString();
            }
        }

        public IHtmlNode AddClass(params string[] classes)
        {
            //Not using tagBuilder.AddCssClass as it prepends the value
            foreach (string @class in classes)
            {
                string value;
                if (Attributes().TryGetValue("class", out value))
                {
                    Attributes()["class"] = value + " " + @class;
                }
                else
                {
                    Attributes()["class"] = @class;
                }
            }

            return this;
        }

        public IHtmlNode Css(string key, string value)
        {
            string style;

            if (Attributes().TryGetValue("style", out style))
            {
                Attributes()["style"] = style + ";" + key + ":" + value;
            }
            else
            {
                Attributes()["style"] = key + ":" + value;
            }

            return this;
        }

        public IHtmlNode PrependClass(string[] classes)
        {
            foreach (string @class in classes.Reverse())
            {
                _tagBuilder.AddCssClass(@class);
            }

            return this;
        }

        public IHtmlNode ToggleClass(string @class, bool condition)
        {
            if (condition)
            {
                AddClass(@class);
            }

            return this;
        }

        public IHtmlNode Attributes(object attributes)
        {
            Attributes<string, object>(new RouteValueDictionary(attributes));

            return this;
        }

        public IHtmlNode Attributes<TKey, TValue>(IDictionary<TKey, TValue> values)
        {
            return Attributes(values, true);
        }

        public IHtmlNode Attributes<TKey, TValue>(IDictionary<TKey, TValue> values, bool replaceExisting)
        {
            _tagBuilder.MergeAttributes(values, replaceExisting);

            return this;
        }

        public IHtmlNode AppendTo(IHtmlNode parent)
        {
            parent.Children.Add(this);

            return this;
        }

        public IHtmlNode Attribute(string key, string value)
        {
            return Attribute(key, value, true);
        }

        public IHtmlNode Attribute(string key, string value, bool replaceExisting)
        {
            _tagBuilder.MergeAttribute(key, value, replaceExisting);

            return this;
        }

        public IHtmlNode Html(string value)
        {
            Children.Clear();

            Children.Add(new LiteralNode(value));

            return this;
        }

        public IHtmlNode Template(Action value)
        {
            TemplateCallback = value;

            return this;
        }

        public Action Template()
        {
            return TemplateCallback;
        }

        public string InnerHtml
        {
            get
            {
                if (Children.Any())
                {
                    StringBuilder innerHtml = new StringBuilder();

                    foreach (IHtmlNode child in Children)
                    {
                        innerHtml.Append(child.ToString());
                    }

                    return innerHtml.ToString();
                }

                return _tagBuilder.InnerHtml;
            }
        }

        public IHtmlNode ToggleAttribute(string key, string value, bool condition)
        {
            if (condition)
            {
                Attribute(key, value);
            }

            return this;
        }

        public IHtmlNode Text(string value)
        {
            _tagBuilder.SetInnerText(value);

            Children.Clear();

            return this;
        }

        public void WriteTo(TextWriter output)
        {
            if (RenderMode != TagRenderMode.SelfClosing)
            {
                output.Write(_tagBuilder.ToString(TagRenderMode.StartTag));

                if (TemplateCallback != null)
                {
                    TemplateCallback();
                }
                else if (Children.Any())
                {
                    foreach (IHtmlNode child in Children)
                    {
                        child.WriteTo(output);
                    }
                }
                else
                {
                    output.Write(_tagBuilder.InnerHtml);
                }

                output.Write(_tagBuilder.ToString(TagRenderMode.EndTag));
            }
            else
            {
                output.Write(_tagBuilder.ToString(TagRenderMode.SelfClosing));
            }
        }

    }
}