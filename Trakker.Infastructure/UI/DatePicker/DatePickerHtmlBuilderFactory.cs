using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Infastructure.UI
{
    public class DatePickerHtmlBuilderFactory : IDatePickerHtmlBuilderFactory
    {
        public IDatePickerBaseHtmlBuilder Create(DatePickerBase element)
        {
            return new DatePickerBaseHtmlBuilder(element);
        }
    }
}
