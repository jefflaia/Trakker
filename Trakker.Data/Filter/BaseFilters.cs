using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public static class BaseFilters
    {
        public static Paginated<T> AsPaginated<T>(this IQueryable<T> qry, int index, int pageSize)
        {
            return new Paginated<T>()
            {
                TotalItems = qry.Count<T>(),
                Items = qry.Skip<T>(index * pageSize).Take<T>(pageSize).ToList<T>(),
                Index = index
            };

        }
    }
}
