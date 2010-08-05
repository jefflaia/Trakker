using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public static class SeverityFilters
    {
        public static IQueryable<Severity> WithId(this IQueryable<Severity> qry, int id)
        {
            return from s in qry
                   where
                       s.SeverityId == id
                   select s;

        }

        public static IQueryable<Severity> WithName(this IQueryable<Severity> qry, string name)
        {
            return from s in qry
                   where
                       s.Name == name
                   select s;

        }
    }
}