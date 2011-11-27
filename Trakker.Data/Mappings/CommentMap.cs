using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Trakker.Data.Mappings
{
    public class CommentMap : ClassMap<Comment>
    {
        public CommentMap()
        {
            Id(p => p.Id).GeneratedBy.Identity();
            Map(p => p.Body);
            Map(p => p.Created);
            Map(p => p.Modified);
            Map(p => p.TicketId);
            Map(p => p.UserId);

            References<Ticket>(p => p.Ticket);
            References<User>(p => p.User, "UserId");
        }
    }
}
