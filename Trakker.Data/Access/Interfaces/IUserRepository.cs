using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public interface IUserRepository
    {
        IQueryable<User> GetUsers();

        void Save(User user);

        void DeleteUser(int id);
    }
}
