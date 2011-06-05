using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public class ColorPalette
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string NavBackgroundColor { get; set; }
        public virtual string SubNavBackgroundColor { get; set; }
        public virtual string HighlightColor { get; set; }
        public virtual string NavTextColor { get; set; }
        public virtual string SubNavTextColor { get; set; }
        public virtual string LinkColor { get; set; }
    }
}
