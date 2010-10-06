using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web; 



namespace Trakker.Core.Forms
{
    public class FormRow
    {
        protected IList<string> _rightMarkup;
        protected IList<string> _leftMarkup;
        protected string _description;

        public FormRow()
        {

            _rightMarkup = new List<string>();
            _leftMarkup = new List<string>();
        }

        public FormRow AddToRight(MvcHtmlString markup)
        {
            return AddToRight(markup.ToString());
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

        public FormRow SetDescription(string description)
        {
            _description = description;
            return this;
        }


        public string Render()
        {
            TagBuilder containerDiv = new TagBuilder("div");

            
            containerDiv.AddCssClass("Row");
            containerDiv.InnerHtml = String.Concat(BuildLeft(), Buildright());

            return containerDiv.ToString();
        }

        public override string ToString()
        {
            return Render();
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

            p.SetInnerText(_description);
            return p.ToString();
        }

        
    }
}
