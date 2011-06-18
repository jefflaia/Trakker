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

    public class UserRepository : Repository, IUserRepository
    {

        public UserRepository(ISession session) : base(session)
        {

        }

        #region User
        public User GetUserById(int userId)
        {
            return GetById<User>(userId);
        }

        public User GetUserByEmail(string email)
        {
            return GetSingleBy<User>(x => x.Email, email);
        }

        public void Save(User user)
        {
            if (user.Id == 0)
            {
                user.Created = DateTime.Now;
                user.Salt = Auth.SaltGenerator();
                user.Password = Auth.HashPassword(user.Password, user.Salt);
            }

            base.Save(user);
        }

        public IList<User> GetUsers()
        {
            return GetAll<User>();
        }

        public Paginated<User> GetUsersPaginated(int page, int pageSize)
        {
            return GetPaginated<User>(page, pageSize);
        }
        #endregion

        #region Role
        public IList<Role> GetRoles()
        {
            return GetAll<Role>();
        }

        public void Save(Role role)
        {
            base.Save(role);
        }
        #endregion
    }
}
