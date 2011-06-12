using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Data.Services;
using Trakker.Data.Repositories;
using Trakker.Data;

namespace Trakker.Infastructure.Streams.Activity
{
    public class TicketActivityStream : ActivityStream
    {
        public TicketActivityStream(IUserRepository userRepo, ITicketRepository ticketRepo)
            : base(userRepo, ticketRepo)
        {

        }

        public Ticket Ticket { get; set; }

        public override IList<Comment> LoadComments(int take, int skip)
        {
            return _ticketRepo.GetCommentsByTicket(Ticket, take, skip).Items;
        }
    }
}
