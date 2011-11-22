using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Trakker.Data.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(p => p.Id).GeneratedBy.Identity();
            Map(p => p.Created);
            Map(p => p.Email);
            Map(p => p.FailedPasswordAttemptCount);
            Map(p => p.FirstName);
            Map(p => p.LastName);
            Map(p => p.LastFailedLoginAttempt);
            Map(p => p.LastLogin);
            Map(p => p.Password);
            Map(p => p.RoleId);
            Map(p => p.Salt);
            Map(p => p.TotalComments);

            References<Role>(p => p.Role)
                .Column("RoleId")
                .Not.Insert()
                .Not.Update();            
        }
    }
}
