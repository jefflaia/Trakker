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
    public class StatusFiltersTests
    {

        protected ITicketRepository _ticketRepository;


        public StatusFiltersTests()
        {
            _ticketRepository = new TicketRepository();
        }

        [Test]
        public void CanGetStatusUsingFilterWithId()
        {
            Status s = _ticketRepository.GetStatus().WithId(1).SingleOrDefault();

            Assert.IsNotNull(s);
        }

        [Test]
        public void CanGetStatusUsingFilterWithName()
        {
            Status s = _ticketRepository.GetStatus().WithName("Complete").SingleOrDefault();

            Assert.IsNotNull(s);
        }
    }
}
