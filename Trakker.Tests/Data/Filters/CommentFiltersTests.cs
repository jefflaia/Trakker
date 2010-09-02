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
    public class CommentFiltersTests
    {

        protected ITicketRepository _ticketRepository;


        public CommentFiltersTests(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        [Test]
        public void CanGetCommentUsingFilterWithId()
        {
            Comment c = _ticketRepository.GetComments().WithId(3).SingleOrDefault();

            Assert.IsNotNull(c);
        }

        [Test]
        public void CanGetCommentUsingFilterWithUserId()
        {
            Comment c = _ticketRepository.GetComments().WithUserId(1).SingleOrDefault();

            Assert.IsNotNull(c);
        }

        [Test]
        public void CanGetCommentUsingFilterWithticketId()
        {
            Comment c = _ticketRepository.GetComments().WithTicketId(10).SingleOrDefault();

            Assert.IsNotNull(c);
        }

    }
}
