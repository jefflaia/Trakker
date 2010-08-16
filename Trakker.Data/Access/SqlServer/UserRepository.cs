using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Data.Linq;

namespace Trakker.Data
{
    using Sql = Access.SqlServer;

    public class UserRepository : IUserRepository
    {
        protected Sql.TrakkerDBDataContext _db = new Sql.TrakkerDBDataContext();

        public IQueryable<User> GetUsers()
        {
            return from u in _db.Users
                   select new User()
                   {
                       UserId = u.UserId,
                       Email = u.Email,
                       Created = u.Created,
                       Password = u.Password,
                       Salt = u.Salt,
                       LastLogin = u.LastLogin,
                       LastFailedLoginAttempt = u.LastFailedLoginAttempt,
                       FailedPasswordAttemptCount = u.FailedPasswordAttemptCount,
                       TotalComments = u.TotalComments,
                       RoleId = u.RoleId
                   };
        }

        public void Save(User user)
        {
            using(Sql.TrakkerDBDataContext ctx = new Sql.TrakkerDBDataContext())
            {

                Mapper.CreateMap<User, Sql.User>();
                Sql.User u = Mapper.Map<User, Sql.User>(user);

                if (user.UserId == 0)
                {
                    ctx.Users.InsertOnSubmit(u);
                }
                else
                {
                    ctx.Users.Attach(u);
                    ctx.Users.Context.Refresh(RefreshMode.KeepCurrentValues, u);
                }

                ctx.SubmitChanges();

                user.UserId = u.UserId;
            };
        }

        public void DeleteUser(int id)
        {
            using (Sql.TrakkerDBDataContext ctx = new Sql.TrakkerDBDataContext())
            {
                ctx.Users.DeleteAllOnSubmit(from u in ctx.Users
                                               where u.UserId == id
                                               select u);
                ctx.SubmitChanges();
            }
        }
    }
}
