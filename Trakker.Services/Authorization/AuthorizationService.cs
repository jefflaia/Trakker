using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Data;
using System.Security.Cryptography;
using System.Web.Security;


namespace Trakker.Services
{
    public abstract class AuthorizationService
    {
        

        protected static IUserService _userService = new UserService();

        private static User _currentUser;
        public static User CurrentUser { 
            get
            {
                if (_currentUser == null)
                {
                    return GetUser();
                }
                else
                {
                    return _currentUser;
                }
            }
            set
            {
                _currentUser = value;
            }
        }

        public static bool IsUserLoggedIn()
        {
            if (GetUser() != null)
            {
               return true;
            }

            return false;
        }

        public static bool ValidateCredentials(string email, string password)
        {
            User user = _userService.GetUserWithEmail(email);
            string hashedPassword = _userService.HashPassword(password, user.Salt);

            if (user == null)
            {
                return false;
            }

            if (String.Compare(user.Password, hashedPassword, false) == 0)
            {
                return true;
            }

            return false;
        }

        public static void LogUserIn(User user)
        {
            CurrentUser = _userService.GetUserWithEmail(user.Email);
            SessionHandler.CreateCookie(user.Email);
        }

        public static void LogUserOut()
        {
            SessionHandler.RemoveCookie();
            CurrentUser = null;
        }
        
        protected static User GetUser()
        {
            string cookieValue = SessionHandler.ReadCookie();

            if (!cookieValue.Equals(string.Empty))
            {
                return _userService.GetUserWithEmail(cookieValue);
            }

            return null;
        }
    
        

    }
}
