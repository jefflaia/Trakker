using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;



namespace Trakker.Core.Forms
{
    public class FormRow : IHtmlString
    {
        protected IList<string> _rightMarkup;
        protected IList<string> _leftMarkup;
        protected IList<string> _description;

        public FormRow()
        {
            _rightMarkup = new List<string>();
            _leftMarkup = new List<string>();
            _description = new List<string>();
        }

        public FormRow AddToRight(MvcHtmlString markup)
        {
            if (markup != null)
            {
                return AddToRight(markup.ToString());
            }

            return this;
        }
        
        public FormRow AddToRight(string markup)
        {
            _rightMarkup.Add(markup);
            return this;
        }

        public FormRow AddToLeft(MvcHtmlString markup)
        {
            return AddToLeft(markup.ToString());
        }

        public FormRow AddToLeft(string markup)
        {
            _leftMarkup.Add(markup);
            return this;
        }

        public FormRow AppendDescription(string description)
        {
            _description.Add(description);
            return this;
        }


        public string Render()
        {
            TagBuilder containerDiv = new TagBuilder("div");

            
            containerDiv.AddCssClass("Row");
            containerDiv.InnerHtml = String.Concat(BuildLeft(), Buildright());

            return containerDiv.ToString();
        }

        protected string BuildLeft()
        {
            TagBuilder leftDiv = new TagBuilder("div");
            string leftMarkup = String.Empty;

            foreach (string markup in _leftMarkup)
            {
                leftMarkup = String.Concat(leftMarkup, markup);
            }

            leftDiv.AddCssClass("Left");
            leftDiv.InnerHtml = leftMarkup;

            return leftDiv.ToString();
        }

        protected string Buildright()
        {
            TagBuilder rightDiv = new TagBuilder("div");
            string rightMarkup = String.Empty;

            foreach (string markup in _rightMarkup)
            {
                rightMarkup = String.Concat(rightMarkup, markup);
            }

            rightMarkup = String.Concat(rightMarkup, BuildDescription());

            rightDiv.AddCssClass("Right");
            rightDiv.InnerHtml = rightMarkup;

            return rightDiv.ToString();
        }

        protected string BuildDescription()
        {
            TagBuilder p = new TagBuilder("p");
            p.AddCssClass("Description");

            string descriptionText = String.Empty;

            foreach (string description in _description)
            {
                descriptionText = String.Concat(descriptionText, description);
            }

            p.SetInnerText(descriptionText);
            return p.ToString();
        }

        public FormRow AddToRight(object viewComponentBuilderBase)
        {
            AddToRight(viewComponentBuilderBase.ToString());
            return this;
        }

        string IHtmlString.ToHtmlString()
        {
            return Render();
        }
    }
}
