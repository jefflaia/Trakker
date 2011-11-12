using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Infastructure.Uploading;

namespace Trakker.Infastructure.UI
{
    public class DatePickerBuilder : DatePickerBuilderBase<DatePickerBase, DatePickerBuilder>
    {
        public DatePickerBuilder(DatePickerBase component)
            : base(component)
        {
        }
    }
}
