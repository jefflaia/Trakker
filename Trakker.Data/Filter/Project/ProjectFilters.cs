using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public static class ProjectFilters
    {
        public static IQueryable<Project> WithId(this IQueryable<Project> qry, int id)
        {
            return from p in qry
                   where
                       p.Id == id
                   select p;
        }

        public static IQueryable<Project> WithName(this IQueryable<Project> qry, string name)
        {
            return from p in qry
                   where
                       p.Name == name
                   select p;
        }

        public static IQueryable<Project> WithKeyName(this IQueryable<Project> qry, string keyName)
        {
            return from p in qry
                   where
                       p.KeyName == keyName
                   select p;
        }
    }

}