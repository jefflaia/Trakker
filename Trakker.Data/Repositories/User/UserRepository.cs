namespace Trakker.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.Linq;

    using Sql = Access;
    using NHibernate;
    using NHibernate.Cfg;

    public class UserRepository : IUserRepository
    {
        protected DataContext _dataContext;
        protected Table<Sql.Role> _rolesTable;
        protected Table<Sql.User> _usersTable;

        protected ISession _session;

        public UserRepository(IDataContextProvider dataContext, ISession session)
        {
            _dataContext = dataContext.DataContext;
            _rolesTable = _dataContext.GetTable<Sql.Role>();
            _usersTable = _dataContext.GetTable<Sql.User>();

            _session = session;

        }

        public IQueryable<User> GetUsers()
        {
            return from u in _usersTable
                   select new User()
                   {
                       Id = u.Id,
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
                       LastName = u.LastName
                   };
        }

        public User GetUserById(int userId)
        {
            return _session.Get<User>(userId);
        }

        public User GetUserByEmail(string email)
        {
            return _session.CreateQuery("from User s where s.Email = ?")
                .SetString(0, email)
                .UniqueResult<User>();
        }

        public IList<User> GetAllUsers()
        {
            return _session.CreateCriteria("from Users s")
                .List<User>();
        }

        public void Save(User user)
        {
            Sql.User u = new Sql.User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                Created = user.Created,
                Email = user.Email,
                FailedPasswordAttemptCount = user.FailedPasswordAttemptCount,
                LastFailedLoginAttempt = user.LastFailedLoginAttempt,
                Password = user.Password,
                Salt = user.Salt,
                LastLogin = user.LastLogin,
                LastName = user.LastName,
                TotalComments = user.TotalComments,
                RoleId = user.RoleId
            };
            


            if (user.Id == 0)
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
                                            where u.Id == id
                                            select u);
   
        }

        public IQueryable<Role> GetRoles()
        {
            return from r in _rolesTable
                   select new Role()
                   {
                       Id = r.Id,
                       Description = r.Description,
                       Name = r.Name
                   };
        }

        public void Save(Role role)
        {
            //Mapper.CreateMap<Role, Sql.Role>();
            //Sql.Role r = Mapper.Map<Role, Sql.Role>(role);
            Sql.Role r = null;

            if (r.Id == 0)
            {
                _rolesTable.InsertOnSubmit(r);
            }
            else
            {
                _rolesTable.Attach(r);
                _rolesTable.Context.Refresh(RefreshMode.KeepCurrentValues, r);
            }

            role.Id = r.Id;
        }
    }
}
