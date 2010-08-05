using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public static class CategoryFilters
    {
        public static IQueryable<Category> WithId(this IQueryable<Category> qry, int categoryId)
        {
            return from c in qry
                   where
                       c.CategoryId == categoryId
                   select c;

        }
   
        public static IQueryable<Category> WithName(this IQueryable<Category> qry, string name)
        {
            return from c in qry
                   where
                       c.Name == name
                   select c;

        }
    }

}