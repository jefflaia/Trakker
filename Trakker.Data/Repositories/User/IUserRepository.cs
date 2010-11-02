namespace Trakker.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IUserRepository
    {
        IQueryable<User> GetUsers();
        void Save(User user);
        void DeleteUser(int id);

        IQueryable<Role> GetRoles();
        void Save(Role role);
        
    }
}
