﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Data.Services;
using Trakker.Data;

namespace Trakker.Infastructure.Streams.Activity
{
    public class UserActivityStream : ActivityStream
    {

        public UserActivityStream(IUserService userService, ITicketService ticketService)
            : base(userService, ticketService)
        {
        }

        public override IList<Comment> LoadComments(int take, int skip)
        {
            return _ticketService.GetComments(take, skip);
        }
    }
}