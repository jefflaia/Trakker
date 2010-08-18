using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Data;
using System.Security.Cryptography;


namespace Trakker.Services
{
   public class UserService : IUserService
    {
       IUserRepository _userRepository;
       const int SALT_LENGTH = 10;

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

       public void Save(User user)
       {
           if (user.UserId == 0)
           {
               var now = DateTime.Now;

               user.Created = now;
               user.LastLogin = now;
               user.LastFailedLoginAttempt = now;
               user.Salt = SaltGenerator();
               user.Password = HashPassword(user.Password, user.Salt);
           }

           _userRepository.Save(user);
       }

       public IList<Role> GetAllRoles()
       {
           return _userRepository.GetRoles().ToList<Role>();
       }

       public string SaltGenerator()
       {
           return RandomHash.Generate(SALT_LENGTH);
       }

       public string HashPassword(string password, string salt)
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
