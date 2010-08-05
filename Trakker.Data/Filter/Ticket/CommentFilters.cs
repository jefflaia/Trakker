using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public static class CommentFilters
    {
        public static IQueryable<Comment> WithId(this IQueryable<Comment> qry, int id)
        {
            return from c in qry
                   where
                       c.CommentId == id
                   select c;
        }

        public static IQueryable<Comment> WithUserId(this IQueryable<Comment> qry, int id)
        {
            return from c in qry
                   where
                       c.UserId == id
                   select c;
        }

        public static IQueryable<Comment> WithTicketId(this IQueryable<Comment> qry, int id)
        {
            return from c in qry
                   where
                       c.TicketId == id
                   select c;
        }
    }

}