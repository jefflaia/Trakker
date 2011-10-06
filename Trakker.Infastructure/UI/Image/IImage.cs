using System;
using System.Collections.Generic;
namespace Trakker.Infastructure.UI
{
    public interface IImage
    {
        IDictionary<string, object> InputHtmlAttributes { get; set; }
        string Alt { get; set; }
        int Height { get; set; }
        string Src { get; set; }
        int Width { get; set; }
    }
}
