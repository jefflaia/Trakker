using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Trakker.Data.Mappings
{
    public class ColorPaletteMap : ClassMap<ColorPalette>
    {
        public ColorPaletteMap()
        {
            Id(p => p.Id).GeneratedBy.Identity();
            Map(p => p.NavBackgroundColor);
            Map(p => p.SubNavBackgroundColor);
            Map(p => p.HighlightColor);
            Map(p => p.NavTextColor);
            Map(p => p.SubNavTextColor);
            Map(p => p.LinkColor);
            Map(p => p.Name);

        }
    }
}
