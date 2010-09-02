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
    public class CategoryFiltersTests
    {

        protected ITicketRepository _ticketRepository;


        public CategoryFiltersTests(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        [Test]
        public void CanGetCategoryUsingFilterWithId()
        {
            Category c = _ticketRepository.GetCategories().WithId(1).SingleOrDefault();

            Assert.IsNotNull(c);
        }

        [Test]
        public void CanGetCategoryUsingFilterWithName()
        {
            Category c = _ticketRepository.GetCategories().WithName("Bug").SingleOrDefault();

            Assert.IsNotNull(c);
        }
    }
}
