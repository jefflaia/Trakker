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
        const int SALT_LENGTH = 10;

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
            string hashedPassword = HashPassword(password, user.Salt);

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
    
        public static string SaltGenerator()
        {
            return RandomHash.Generate(SALT_LENGTH);
        }

        public static string HashPassword(string password, string salt)
        {
           

            // Convert plain text into a byte array.
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);

            // Allocate array, which will hold plain text and salt.
            byte[] passwordWithSaltBytes =
                    new byte[passwordBytes.Length + saltBytes.Length];

            // Copy plain text bytes into resulting array.
            for (int i = 0; i < passwordBytes.Length; i++)
                passwordWithSaltBytes[i] = passwordBytes[i];

            // Append salt bytes to the resulting array.
            for (int i = 0; i < saltBytes.Length; i++)
                passwordWithSaltBytes[passwordBytes.Length + i] = saltBytes[i];

            HashAlgorithm hash = new SHA512Managed();

            // Compute hash value of our plain text with appended salt.
            byte[] hashBytes = hash.ComputeHash(passwordWithSaltBytes);

            // Create array which will hold hash and original salt bytes.
            byte[] hashWithSaltBytes = new byte[hashBytes.Length +
                                                saltBytes.Length];

            // Copy hash bytes into resulting array.
            for (int i = 0; i < hashBytes.Length; i++)
                hashWithSaltBytes[i] = hashBytes[i];

            // Append salt bytes to the result.
            for (int i = 0; i < saltBytes.Length; i++)
                hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];

            // Convert result into a base64-encoded string.
            string hashValue = Convert.ToBase64String(hashWithSaltBytes);

            // Return the result.
            return hashValue;

        }

    }
}
