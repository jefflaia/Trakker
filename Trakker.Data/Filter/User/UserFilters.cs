using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public static class UserFilters
    {
        public static IQueryable<User> WithEmail(this IQueryable<User> qry, string email)
        {
            return from u in qry
                   where u.Email.ToLower() == email.ToLower()
                   select u;
        }

    }
}
