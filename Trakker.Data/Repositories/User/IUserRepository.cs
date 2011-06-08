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
        User GetUserById(int userId);
        User GetUserByEmail(string email);
        //IList<User> GetAllUser();
        //Paginated<User> GetAllUsersPaginated(int page, int pageSize);

        IQueryable<Role> GetRoles();
        void Save(Role role);
        //IList<Role> GetAllRoles();
        
    }
}
