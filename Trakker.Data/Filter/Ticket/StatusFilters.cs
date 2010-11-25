using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public static class StatusFilters
    {
        public static IQueryable<TicketStatus> WithId(this IQueryable<TicketStatus> qry, int id)
        {
            return from s in qry
                   where
                       s.Id == id
                   select s;

        }

        public static IQueryable<TicketStatus> WithName(this IQueryable<TicketStatus> qry, string name)
        {
            return from s in qry
                   where
                       s.Name == name
                   select s;

        }
    }
}