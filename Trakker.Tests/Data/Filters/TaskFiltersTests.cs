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
    public class ticketFiltersTests
    {

        protected ITicketRepository _ticketRepository;


        public ticketFiltersTests(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }





    }
}
