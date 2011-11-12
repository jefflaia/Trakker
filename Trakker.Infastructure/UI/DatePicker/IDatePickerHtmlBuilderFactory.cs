using System;
namespace Trakker.Infastructure.UI
{
    public interface IDatePickerHtmlBuilderFactory
    {
        IDatePickerBaseHtmlBuilder Create(DatePickerBase element);
    }
}
