using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Trakker.Data.Mappings
{
    class ProjectMap : ClassMap<Project>
    {
        public ProjectMap()
        {
            Id(p => p.Id).GeneratedBy.Identity();
            Map(p => p.Name);
            Map(p => p.KeyName);
            Map(p => p.Lead);
            Map(p => p.Due);
            Map(p => p.Created);
            Map(p => p.TicketIndex);
            Map(p => p.Url);
            Map(p => p.ColorPaletteId);

            References<ColorPalette>(p => p.ColorPalette)
                .Column("ColorPaletteId")
                .Not.Insert()
                .Not.Update();

            References<File>(p => p.Avatar)
                .Column("AvatarId")
                .Not.Insert()
                .Not.Update();
            
        }
    }
}
