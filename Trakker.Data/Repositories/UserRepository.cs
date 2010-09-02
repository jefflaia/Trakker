using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Data.Linq;

namespace Trakker.Data
{
    using Sql = Access;

    public class UserRepository : IUserRepository
    {
        protected DataContext _db;

        public UserRepository(IDataContextProvider dataContext)
        {
            _db = dataContext.DataContext;
        }

        public IQueryable<User> GetUsers()
        {
            return from u in _db.GetTable<Sql.User>()
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

        public IQueryable<Role> GetRoles()
        {
            return from r in _db.GetTable<Sql.Role>()
                   select new Role()
                   {
                       RoleId = r.RoleId,
                       Description = r.Description,
                       Name = r.Name
                   };
        }

        public void Save(Role role)
        {
            using (Sql.TrakkerDBDataContext ctx = new Sql.TrakkerDBDataContext())
            {

                Mapper.CreateMap<Role, Sql.Role>();
                Sql.Role r = Mapper.Map<Role, Sql.Role>(role);

                if (r.RoleId == 0)
                {
                    ctx.Roles.InsertOnSubmit(r);
                }
                else
                {
                    ctx.Roles.Attach(r);
                    ctx.Roles.Context.Refresh(RefreshMode.KeepCurrentValues, r);
                }

                ctx.SubmitChanges();

                role.RoleId = r.RoleId;
            };
        }
    }
}
