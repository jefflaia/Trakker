using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;
using NHibernate;
using Trakker.Data.Utilities;

namespace Trakker.Tests.Data.Utilities
{
    [TestFixture]
    public class UnitOfWorkTests
    {
        Mock<ISession> _mockSession;

        public UnitOfWorkTests()
        {
            _mockSession = new Mock<ISession>();
        }


        [Test]
        public void Begin_Creates_Transaction()
        {
            var uow = new UnitOfWork(_mockSession.Object);
            uow.Begin();
            _mockSession.Verify(s => s.BeginTransaction());
        }

        [Test]
        public void Commit_Throws_InvalidOperationException_When_No_Transaction()
        {
            var uow = new UnitOfWork(_mockSession.Object);
            Assert.Throws(typeof(InvalidOperationException), () => uow.Commit());
        }

        [Test]
        public void Rollback_Throws_InvalidOperationException_When_No_Transaction()
        {
            var uow = new UnitOfWork(_mockSession.Object);
            Assert.Throws(typeof(InvalidOperationException), () => uow.Commit());
        }
    }
}
