using System;
using System.Collections.Generic;
namespace Trakker.Infastructure.UI
{
    public interface IImage
    {
        string Alt { get; set; }
        int Height { get; set; }
        string Src { get; set; }
        int Width { get; set; }
    }
}
