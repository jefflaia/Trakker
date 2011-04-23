using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Data;
using Trakker.Infastructure.Streams.Activity.Model;

namespace Trakker.Infastructure.Streams.Activity.Mappers
{
    internal class CommentMapper : IMapper<Comment>
    {
        public ActivityModel Map(Comment comment)
        {
            return new ActivityModel()
            {
                Comment = comment.Body,
                Created = comment.Created,
                UserId = comment.UserId,
                TicketId = comment.TicketId,
            };
        }
    }
}
