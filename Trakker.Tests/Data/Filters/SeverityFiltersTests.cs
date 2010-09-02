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
    public class SeverityFiltersTests
    {

        protected ITicketRepository _ticketRepository;


        public SeverityFiltersTests(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        [Test]
        public void CanGetSeverityUsingFilterWithId()
        {
            Severity s = _ticketRepository.GetSeverities().WithId(1).SingleOrDefault();

            Assert.IsNotNull(s);
        }

        [Test]
        public void CanGetSeverityUsingFilterWithName()
        {
            Severity s = _ticketRepository.GetSeverities().WithName("Critical").SingleOrDefault();

            Assert.IsNotNull(s);
        }
    }
}
