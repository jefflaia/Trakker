using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;
using Trakker.Data.Repositories;
using Trakker.Infastructure.Streams.Activity;

namespace Trakker.Tests.Infastructure.ActivityStream
{
    [TestFixture]
    public class ActivityStreamTests
    {
        private UserActivityStream _stream;

        public ActivityStreamTests()
        {
            var mockUserRepo = new Mock<IUserRepository>();
            var mockTicketRepo = new Mock<ITicketRepository>();
            _stream = new UserActivityStream(mockUserRepo.Object, mockTicketRepo.Object);
        }

        
    }
}
