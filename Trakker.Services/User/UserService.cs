using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Data;


namespace Trakker.Services
{
   public class UserService : IUserService
    {
       IUserRepository _userRepository;

       public UserService()
       {
           _userRepository = new UserRepository();
       }

       public User GetUserWithId(int id)
       {
           return _userRepository.GetUsers().Where(x => x.UserId == id).SingleOrDefault<User>() ?? null;
       }

       public User GetUserWithEmail(string email)
       {
           return _userRepository.GetUsers().Where(x => x.Email == email).SingleOrDefault<User>() ?? null;
       }

       public IList<User> GetAllUsers()
       {
           return _userRepository.GetUsers().ToList<User>();
       }




   }
}
