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
    public class PriorityFiltersTests
    {

        protected ITicketRepository _ticketRepository;


        public PriorityFiltersTests()
        {
            _ticketRepository = new TicketRepository();
        }

        [Test]
        public void CanGetPriorityUsingFilterWithId()
        {
            Priority p = _ticketRepository.GetPriorities().WithId(1).SingleOrDefault();

            Assert.IsNotNull(p);
        }

        [Test]
        public void CanGetPriorityUsingFilterWithName()
        {
            Priority p = _ticketRepository.GetPriorities().WithName("Low").SingleOrDefault();

            Assert.IsNotNull(p);
        }
    }
}
