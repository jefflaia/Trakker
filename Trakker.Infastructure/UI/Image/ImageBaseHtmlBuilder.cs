using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Infastructure.Uploading;
using Trakker.Core;

namespace Trakker.Infastructure.UI
{
    public class ImageBaseHtmlBuilder : IImageBaseHtmlBuilder
    {
        public ImageBase Element { get; set; }
        
        public ImageBaseHtmlBuilder(ImageBase element)
        {
            Element = element;
        }

        public IHtmlNode Build()
        {
            return new HtmlTag("img")
                .Attribute("width", Element.Width.ToString())
                .Attribute("height", Element.Height.ToString())
                .Attribute("src", Element.Src)
                .Attribute("alt", Element.Alt);
        }
    }
}
