using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public static class TicketFilters
    {
        public static IQueryable<Ticket> WithId(this IQueryable<Ticket> qry, int ticketId)
        {
            return from t in qry
                   where
                       t.Id == ticketId
                   select t;
        }

        public static IQueryable<Ticket> WithKeyName(this IQueryable<Ticket> qry, string keyName)
        {
            return from t in qry
                   where
                       t.KeyName == keyName
                   select t;
        }

        public static IQueryable<Ticket> WithProjectId(this IQueryable<Ticket> qry, int projectId)
        {
            return from t in qry
                   where
                       t.ProjectId == projectId
                   select t;
        }
    }
}
