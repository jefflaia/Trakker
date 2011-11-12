using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Infastructure.Uploading;
using System.Linq.Expressions;

namespace Trakker.Infastructure.UI
{
    public class DatePickerBuilderBase<TComponent, TBuilder> : ViewComponentBuilderBase<TComponent, TBuilder>
        where TComponent : DatePickerBase
        where TBuilder : DatePickerBuilderBase<TComponent, TBuilder>
    {

        private TComponent Component { get; set; }

        public DatePickerBuilderBase(TComponent component) :
            base(component)
        {
            Component = component;
        }

        public TBuilder Value(DateTime? date)
        {
            Component.Value = date;

            return this as TBuilder;
        }

        public TBuilder Value(string date)
        {
            DateTime parsedDate;

            if (DateTime.TryParse(date, out parsedDate))
            {
                Component.Value = parsedDate;
            }
            else
            {
                Component.Value = null;
            }
            return this as TBuilder;
        }

        public TBuilder Name(string name)
        {
            Component.Name = name;

            return this as TBuilder;
        }
    }
}
