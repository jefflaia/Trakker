using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public static class StatusFilters
    {
        public static IQueryable<Status> WithId(this IQueryable<Status> qry, int id)
        {
            return from s in qry
                   where
                       s.StatusId == id
                   select s;

        }

        public static IQueryable<Status> WithName(this IQueryable<Status> qry, string name)
        {
            return from s in qry
                   where
                       s.Name == name
                   select s;

        }
    }
}