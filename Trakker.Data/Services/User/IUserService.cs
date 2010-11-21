
namespace Trakker.Data.Services
{
    using System;
    using Trakker.Data;
    using System.Collections.Generic;

    public interface IUserService
    {
        IList<Role> GetAllRoles();
        IList<User> GetAllUsers();
        Paginated<User> GetAllUsersPaginated(int page, int pageSize);
        User GetUserWithEmail(string email);
        User GetUserWithId(int id);
        void Save(User user);

        void Save(Role role);
    }
}
