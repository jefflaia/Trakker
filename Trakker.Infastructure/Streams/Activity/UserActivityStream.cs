using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Data.Services;
using Trakker.Data;
using Trakker.Data.Repositories;

namespace Trakker.Infastructure.Streams.Activity
{
    public class UserActivityStream : ActivityStream
    {

        public UserActivityStream(IUserRepository userRepo, ITicketRepository ticketRepo)
            : base(userRepo, ticketRepo)
        {
        }

        public User User { get; set; }

        public override IList<Comment> LoadComments(int take, int skip)
        {
            return _ticketRepo.GetCommentsByUser(User, take, skip);
        }
    }
}
