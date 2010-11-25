using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public static class CategoryFilters
    {
        public static IQueryable<TicketType> WithId(this IQueryable<TicketType> qry, int categoryId)
        {
            return from c in qry
                   where
                       c.Id == categoryId
                   select c;

        }
   
        public static IQueryable<TicketType> WithName(this IQueryable<TicketType> qry, string name)
        {
            return from c in qry
                   where
                       c.Name == name
                   select c;

        }
    }

}