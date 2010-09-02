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
    public class BaseFiltersTests
    {

        protected ITicketRepository _ticketRepository;


        public BaseFiltersTests(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        [Test]
        public void CanGetPaginatedObjectWithData()
        {
            Paginated<Comment> p = _ticketRepository.GetComments().AsPaginated<Comment>(1, 10);

            Assert.IsNotNull(p);
        }
    }
}
