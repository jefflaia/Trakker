using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public static class PriorityFilters
    {
        public static IQueryable<TicketPriority> WithId(this IQueryable<TicketPriority> qry, int priorityId)
        {
            return from p in qry
                   where
                       p.Id == priorityId
                   select p;
        }

        public static IQueryable<TicketPriority> WithName(this IQueryable<TicketPriority> qry, string name)
        {
            return from p in qry
                   where
                       p.Name == name
                   select p;
        }
    }
}