using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public class ColorPalette
    {
        public int Id { get; set; }
        public string NavBackgroundColor { get; set; }
        public string SubNavBackgroundColor { get; set; }
        public string HighlightColor { get; set; }
        public string NavTextColor { get; set; }
        public string SubNavTextColor { get; set; }
        public string LinkColor { get; set; }
    }
}
