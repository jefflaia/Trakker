namespace Trakker.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class SystemSettings
    {
        public ColorPalette ColorPalette { get; set; }
        public int ColorPaletteId { get; set; }
        public String LogoUrl { get; set; }
        public int LogoWidth { get; set; }
        public int LogoHeight { get; set; }
        public String TimeFormat { get; set; }
        public String DayFormat { get; set; }
        public String DateTimeFormat { get; set; }
        public String DateFormat { get; set; }

    }
}
