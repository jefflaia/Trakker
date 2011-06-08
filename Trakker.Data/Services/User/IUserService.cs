
namespace Trakker.Data.Services
{
    using System;
    using Trakker.Data;
    using System.Collections.Generic;
using System.Linq;

    public interface IUserService
    {
        IList<Role> GetAllRoles();
        IList<User> GetAllUsers();
        Paginated<User> GetAllUsersPaginated(int page, int pageSize);
        User GetUserByEmail(string email);
        User GetUserById(int id);
        void Save(User user);


        void Save(Role role);
    }
}
