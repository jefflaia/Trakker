using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using MbUnit.Framework;
using Gallio.Framework;
using Trakker.Data;
using System.Data.SqlClient;

//TODO:: Generate random string hashes that use all characters to test strings, takes a parameter for length, could be a simple base test BaseDBTest
namespace Trakker.Tests._ticketRepositoryTest 
{
    [TestFixture]
    public class UserRepositoryTest
    {
        protected IUserRepository userRepository;


        public UserRepositoryTest()
        {
            userRepository = new UserRepository();
        }

        #region Gets
        
        [Test]
        public void CanGetUsers()
        {
            IList<User> users = userRepository.GetUsers().ToList<User>();
            Assert.GreaterThan(users.Count, 0);
        }
        
        #endregion

        #region Saves
        [Test]
        [Rollback]
        public void CanInsertUserWithSave()
        {
            User user = new User()
            {
                Email = "test@gmail.ca",
                Password = "2312ljdlkj1lk2jjhdkjsadjlk13j1",
                Salt = "123456",
                Created = DateTime.Today,
                FailedPasswordAttemptCount = 0,
                LastFailedLoginAttempt = DateTime.Today,
                LastLogin = DateTime.Today,
                TotalComments = 0
            };

            userRepository.Save(user);

            Assert.GreaterThan(user.UserId, 0);
        }

        [Test]
        [Rollback]
        public void CanUpdateUserWithSave()
        {

            User user = userRepository.GetUsers()
                .First<User>();

            user.Email = "testing@gmail.ca";
            user.Password = "2312ljdlkj1lk2jjhdkjsadjlk13j1asdasdsa";
            user.Salt = "654321";
            user.Created = DateTime.Today.Add(TimeSpan.FromDays(1));
            user.FailedPasswordAttemptCount = 999;
            user.LastFailedLoginAttempt = DateTime.Today.Add(TimeSpan.FromDays(1));
            user.TotalComments = 999;
            user.LastLogin = DateTime.Today.Add(TimeSpan.FromDays(1));

            userRepository.Save(user);

           User updatedUser = userRepository.GetUsers()
                .Where(x => x.UserId == user.UserId)
                .Single();

            Assert.AreEqual(user.Email, updatedUser.Email);
            Assert.AreEqual(user.Password, updatedUser.Password);
            Assert.AreEqual(user.Salt, updatedUser.Salt);
            Assert.AreEqual(user.Created, DateTime.Today.Add(TimeSpan.FromDays(1)));
            Assert.AreEqual(user.FailedPasswordAttemptCount, 999);
            Assert.AreEqual(user.LastFailedLoginAttempt, DateTime.Today.Add(TimeSpan.FromDays(1)));
            Assert.AreEqual(user.TotalComments, 999);
            Assert.AreEqual(user.LastLogin, DateTime.Today.Add(TimeSpan.FromDays(1)));
        }



        #endregion

        #region Deletes
        [Test]
        [Rollback]
        public void CanDeleteUser()
        {
           const int ID = 10;

           userRepository.DeleteUser(ID);

           User user = userRepository.GetUsers()
               .Where(x => x.UserId == ID)
               .SingleOrDefault<User>();

           Assert.IsNull(user);
        }
        #endregion
    }
}
