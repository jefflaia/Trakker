using System;
using System.Collections.Generic;
namespace Trakker.Infastructure.UI
{
    public interface IProgressBar
    {
        IDictionary<string, object> InputHtmlAttributes { get; set; }
        double Max { get; set; }
        double Current { get; set; }
        string ColorClass { get; set; }
        int Width { get; set; }
        int Height { get; set; }


        double Percentage();
        double BarWidthPercent();
        int BarWidthPixels();
    }
}
