using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Trakker.Infastructure.UI
{
    public class ProgressBar : ViewComponentBase, IProgressBar 
    {
        public ProgressBar(IAssetManager assetManager) :
            base(assetManager)
        {
            //set defaults
            Height = 0;
            Width = 250;
            Current = 0;
            Max = 100;
            ColorClass = CssPrimitives.ProgressBar.Blue;
            BackgroundColorClass = CssPrimitives.ProgressBar.Grey;
        }

        public double Max { get; set; }
        public double Current { get; set; }
        public string ColorClass { get; set; }
        public string BackgroundColorClass { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public double Percentage()
        {
            if (Max == 0.0)
            {
                Max = 1;
            }

            return (Current / Max) * 100;
        }

        public double BarWidthInPercent()
        {
            return Percentage();
        }

        public int BarWidthInPixels()
        {
            if (Max == 0.0)
            {
                Max = 1;
            }

            return Convert.ToInt32(Math.Floor((Current / Max) * Convert.ToDouble(Width)));
        }

    }
}
