using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public static class PriorityFilters
    {
        public static IQueryable<Priority> WithId(this IQueryable<Priority> qry, int priorityId)
        {
            return from p in qry
                   where
                       p.PriorityId == priorityId
                   select p;
        }

        public static IQueryable<Priority> WithName(this IQueryable<Priority> qry, string name)
        {
            return from p in qry
                   where
                       p.Name == name
                   select p;
        }
    }
}