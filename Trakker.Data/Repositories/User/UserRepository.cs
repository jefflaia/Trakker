namespace Trakker.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AutoMapper;
    using System.Data.Linq;

    using Sql = Access;

    public class UserRepository : IUserRepository
    {
        protected DataContext _dataContext;
        protected Table<Sql.Role> _rolesTable;
        protected Table<Sql.User> _usersTable;

        public UserRepository(IDataContextProvider dataContext)
        {
            _dataContext = dataContext.DataContext;
            _rolesTable = _dataContext.GetTable<Sql.Role>();
            _usersTable = _dataContext.GetTable<Sql.User>();
        }

        public IQueryable<User> GetUsers()
        {
            return from u in _usersTable
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
                       RoleId = u.RoleId,
                       FirstName = u.FirstName,
                       LastName = u.LastName,
                       Initial = u.Initial
                   };
        }

        public void Save(User user)
        {
            Mapper.CreateMap<User, Sql.User>();
            Sql.User u = Mapper.Map<User, Sql.User>(user);

            if (user.UserId == 0)
            {
                _usersTable.InsertOnSubmit(u);
            }
            else
            {
                _usersTable.Attach(u);
                _usersTable.Context.Refresh(RefreshMode.KeepCurrentValues, u);
            }
        }

        public void DeleteUser(int id)
        {
            _usersTable.DeleteAllOnSubmit(from u in _usersTable
                                            where u.UserId == id
                                            select u);
   
        }

        public IQueryable<Role> GetRoles()
        {
            return from r in _rolesTable
                   select new Role()
                   {
                       RoleId = r.RoleId,
                       Description = r.Description,
                       Name = r.Name
                   };
        }

        public void Save(Role role)
        {
            Mapper.CreateMap<Role, Sql.Role>();
            Sql.Role r = Mapper.Map<Role, Sql.Role>(role);

            if (r.RoleId == 0)
            {
                _rolesTable.InsertOnSubmit(r);
            }
            else
            {
                _rolesTable.Attach(r);
                _rolesTable.Context.Refresh(RefreshMode.KeepCurrentValues, r);
            }

            role.RoleId = r.RoleId;
        }
    }
}
