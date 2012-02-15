using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Infastructure.Uploading;
using System.Web.UI;

namespace Trakker.Infastructure.UI
{
    public class DatePickerBuilder : DatePickerBuilderBase<DatePickerBase, DatePickerBuilder>
    {
        public DatePickerBuilder(DatePickerBase component, IDatePickerHtmlBuilder htmlBuilder, IClientSideObjectWriterFactory clientSideObjectWriterFactory, HtmlTextWriter writer)
            : base(component, htmlBuilder, clientSideObjectWriterFactory, writer)
        {
        }
    }
}
