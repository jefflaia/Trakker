namespace Trakker.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class SystemSettings
    {
        public ColorPalette ColorPalette { get; set; }
        public String LogoUrl { get; set; }
        public String TimeFormat { get; set; }
        public String DayFormat { get; set; }
        public String DateTimeFormat { get; set; }
        public String DateFormat { get; set; }

    }
}
