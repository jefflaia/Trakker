using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Trakker.Data.Mappings
{
    public class TicketResolutionMap : ClassMap<TicketResolution>
    {
        public TicketResolutionMap()
        {
            Id(p => p.Id).GeneratedBy.Identity();
            Map(p => p.Name);
            Map(p => p.Description);
        }
    }
}
