using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Infastructure.Uploading;
using Trakker.Core;
using System.Web.Mvc;

namespace Trakker.Infastructure.UI
{
    public class DatePickerBaseHtmlBuilder : IDatePickerBaseHtmlBuilder
    {
        public DatePickerBase Element { get; set; }

        public DatePickerBaseHtmlBuilder(DatePickerBase element)
        {
            Element = element;
        }

        public IHtmlNode Build()
        {
            return InputTag();
        }

        public IHtmlNode InputTag()
        {
            ModelState state;
            DateTime? date = null;
            ViewDataDictionary viewData = Element.ViewContext.ViewData;

            if (Element.Value != DateTime.MinValue)
            {
                date = Element.Value;
            }
            else if (viewData.ModelState.TryGetValue(Element.Id, out state))
            {
                if (state.Errors.Count == 0)
                {
                    date = state.Value.ConvertTo(typeof(DateTime), Culture.Current) as DateTime?;
                }
            }

            object valueFromViewData = viewData.Eval(Element.Name);

            if (valueFromViewData != null)
            {
                date = Convert.ToDateTime(valueFromViewData);
            }

            string value = string.Empty;

            if (date != null)
            {
                /*
                if (string.IsNullOrEmpty(Element.Format))
                {
                    value = date.Value.ToShortDateString();
                }
                else
                {
                    value = date.Value.ToString(Element.Format);
                }
                 */
            }

            return new HtmlTag("input", TagRenderMode.SelfClosing)
                .Attributes(new { 
                    name = Element.Name, 
                    id = Element.Id + "-input", 
                    value = value
                })
                .Attributes(Element.InputHtmlAttributes);
        }
    }
}
