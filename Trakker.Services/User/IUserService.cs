using System;
using Trakker.Data;
using System.Collections.Generic;
namespace Trakker.Services
{
    public interface IUserService
    {
        User CurrentUser { get; set; }
        IList<Role> GetAllRoles();
        IList<User> GetAllUsers();
        User GetUserWithEmail(string email);
        User GetUserWithId(int id);
        string HashPassword(string password, string salt);
        bool IsUserLoggedIn();
        void LogUserIn(User user);
        void LogUserOut();
        string SaltGenerator();
        void Save(User user);
        bool ValidateCredentials(string email, string password);
    }
}
