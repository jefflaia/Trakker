using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Data.Services;
using Trakker.Data;
using Trakker.Infastructure.Streams.Activity.Model;

namespace Trakker.Core.Streams.Activity
{
    public class ActivityStream
    {

        private ITicketService _ticketService;
        private IList<User> _users;
        private Ticket _ticket;

        public ActivityStream(Ticket ticket, ITicketService ticketService, IUserService userService)
        {
            _ticketService = ticketService;
            
        }

        private IList<ActivityModel> GenerateFromComments()
        {
            var activities = new List<ActivityModel>();

            foreach (var comment in _ticketService.GetCommentsWithticketId(_ticket.Id))
            {
                activities.Add(new ActivityModel()
                {
                    Id = comment.Id,
                    Comment = comment.Body,
                    Created = comment.Created,
                    IsChange = false,
                    UserId = comment.UserId
                });
            }

            return activities;
        }

        private IList<ActivityModel> Sort(IList<ActivityModel> activities)
        {
            return activities.OrderBy(m => m.Created).Reverse().ToList<ActivityModel>();
        }

        private IList<ActivityGroupModel> Group(IList<ActivityModel> activities)
        {
            //get min / max date
            //loop through each date
            //get activities that are on that date with linq
            //sort
            //create group
            //add to group
            //add group to list
            
            
            var groups = new List<ActivityGroupModel>();

            return groups;
        }
    }
}
