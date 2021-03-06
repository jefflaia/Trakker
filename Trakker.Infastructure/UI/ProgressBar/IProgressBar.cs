﻿using System;
using System.Collections.Generic;
namespace Trakker.Infastructure.UI
{
    public interface IProgressBar
    {
        double Max { get; set; }
        double Current { get; set; }
        string ColorClass { get; set; }
        string BackgroundColorClass { get; set; }
        int Width { get; set; }
        int Height { get; set; }


        double Percentage();
        double BarWidthInPercent();
        int BarWidthInPixels();
    }
}
