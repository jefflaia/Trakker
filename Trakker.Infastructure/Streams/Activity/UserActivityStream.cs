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

        public UserActivityStream(IUserService userService, ITicketService ticketService, IUserRepository userRepo)
            : base(userService, ticketService, userRepo)
        {
        }

        public override IList<Comment> LoadComments(int take, int skip)
        {
            return _ticketService.GetComments(take, skip);
        }
    }
}
