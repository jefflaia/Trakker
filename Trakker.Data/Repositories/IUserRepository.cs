namespace Trakker.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IUserRepository
    {
        IList<User> GetUsers();
        void Save(User user);
        User GetUserById(int userId);
        User GetUserByEmail(string email);
        Paginated<User> GetUsersPaginated(int page, int pageSize);


        IList<Role> GetRoles();
        void Save(Role role);
        
    }
}
