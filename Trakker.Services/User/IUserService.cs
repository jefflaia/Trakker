using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Data;

namespace Trakker.Services
{
    public interface IUserService
    {
        User GetUserWithId(int id);
        User GetUserWithEmail(string email);

        void Save(User user);


        IList<User> GetAllUsers();
    }
}
