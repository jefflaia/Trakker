using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using Gallio.Framework;
using Trakker.Data;

namespace Trakker.Tests.Data.Filters
{



    [TestFixture]
    public class UserFiltersTests
    {

        protected IUserRepository _userRepository;


        public UserFiltersTests()
        {
            _userRepository = new UserRepository();
        }

        [Test]
        public void CanGetUserUsingFilterWithEmail()
        {
            //test that we can get a user with this email
            User user = _userRepository.GetUsers().WithEmail("justin@gmail.ca").SingleOrDefault<User>();
            Assert.IsNotNull(user);

            //test that we can get it with random case
            User user2 = _userRepository.GetUsers().WithEmail("JUstIN@GmaIL.cA").SingleOrDefault<User>();
            Assert.IsNotNull(user2);

        }



    }
}
