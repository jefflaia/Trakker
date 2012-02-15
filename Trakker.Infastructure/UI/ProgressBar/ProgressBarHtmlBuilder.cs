using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Infastructure.Uploading;
using Trakker.Core;

namespace Trakker.Infastructure.UI
{
    public class ProgressBarHtmlBuilder : IProgressBarHtmlBuilder
    {
        public IProgressBar Element { get; set; }

        public ProgressBarHtmlBuilder(IProgressBar element)
        {
            Element = element;
        }

        public IHtmlNode Build()
        {
            IDictionary<string, object> attributes = new Dictionary<string, object>();
            var tag = new HtmlTag("div")
                .AddClass(CssPrimitives.ProgressBar.Container)
                .AddClass(Element.BackgroundColorClass);

            //add the bar    
            tag.Children.Add(this.Bar());

            //add specified height
            if (Element.Height > 0)
            {
                attributes.AddStyleAttribute("height", Element.Height.ToString() + "px");
            }

            //add specified width
            if (Element.Width > 0)
            {
                attributes.AddStyleAttribute("width", Element.Width.ToString() + "px");
            }

            tag.Attributes(attributes);
            
            return tag;                               
        }

        protected IHtmlNode Bar()
        {
            var tag = new HtmlTag("div");
            IDictionary<string, object> attributes = new Dictionary<string, object>();
         
            attributes.AddStyleAttribute("width", Element.BarWidthInPixels().ToString() + "px");
            tag.Attributes(attributes);
            tag.AddClass(Element.ColorClass);

            return tag;                
        }
    }
}
