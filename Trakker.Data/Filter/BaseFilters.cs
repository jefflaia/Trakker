using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public static class BaseFilters
    {
        public static Paginated<T> AsPaginated<T>(this IQueryable<T> qry, int page, int pageSize)
        {
            page--; //because page is actually in index and index starts at zero, but page starts at 1
            return new Paginated<T>()
            {
                TotalItems = qry.Count<T>(),
                Items = qry.Skip<T>(page * pageSize).Take<T>(pageSize).ToList<T>(),
                Index = page
            };

        }
    }
}
