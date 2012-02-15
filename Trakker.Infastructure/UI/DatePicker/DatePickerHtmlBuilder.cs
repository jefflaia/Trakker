using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Infastructure.Uploading;
using Trakker.Core;
using System.Web.Mvc;

namespace Trakker.Infastructure.UI
{
    public class DatePickerHtmlBuilder : IDatePickerHtmlBuilder
    {
        public DatePickerBase Element { get; set; }

        public DatePickerHtmlBuilder(DatePickerBase element)
        {
            Element = element;
        }

        public IHtmlNode Build()
        {
            return InputTag();
        }

        public IHtmlNode InputTag()
        {
            string value = "";
            if (Element.Value != null)
            {
                value = Element.Value.Value.ToString(Element.Format);
            }

            return new HtmlTag("input", TagRenderMode.SelfClosing)
                .Attributes(new { 
                    type = "text",
                    name = Element.Name, 
                    id = Element.Id,
                    value = value
                })
                .Attributes(Element.HtmlAttributes);
        }
    }
}
