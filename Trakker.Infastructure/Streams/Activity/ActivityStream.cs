using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Data.Services;
using Trakker.Data;
using Trakker.Infastructure.Streams.Activity.Model;
using Trakker.Infastructure.Streams.Activity.Mappers;
using Trakker.Data.Repositories;

namespace Trakker.Infastructure.Streams.Activity
{
    abstract public class ActivityStream
    {
        protected IUserRepository _userRepo;
        protected ITicketRepository _ticketRepo;


        private static IMapper<Comment> _commentMapper = new CommentMapper();

        public ActivityStream(IUserRepository userRepo, ITicketRepository ticketRepo)
        {

            _userRepo = userRepo;
            _ticketRepo = ticketRepo;
        }

        public abstract IList<Comment> LoadComments(int take, int skip);

        public IList<ActivityModel> Transform(IList<Comment> comments)
        {
            var activities = new List<ActivityModel>();
            foreach (var comment in comments)
            {
                activities.Add(_commentMapper.Map(comment));
            }

            return activities;
        }

        public IList<ActivityGroupModel> Generate(int take, int skip)
        {
            //get activities
            var activities = Transform(LoadComments(take, skip));

            //load the users into each activity
            LoadUsersAndTickets(activities);

            //sort them by date and time
            activities = Sort(activities);

            //group them by day
            var groups = Group(activities);

            return groups;            
        }

        private void LoadUsersAndTickets(IList<ActivityModel> activities)
        {
            var users = new Dictionary<int, User>();
            var tickets = new Dictionary<int, Ticket>();

            //loop through getting each user and adding it to the activity
            foreach (var activity in activities)
            {
                //if the user does not exist, get it
                //avoid needless queries for already existing users
                if (users.ContainsKey(activity.UserId) == false)
                {
                    users.Add(activity.UserId, _userRepo.GetUserById(activity.UserId));
                }

                if (tickets.ContainsKey(activity.TicketId) == false)
                {
                    tickets.Add(activity.TicketId, _ticketRepo.GetTicketById(activity.TicketId));
                }

                activity.User = users[activity.UserId];
                activity.Ticket = tickets[activity.TicketId];
            }
        }


        private IList<ActivityModel> Sort(IList<ActivityModel> activities)
        {
            return activities.OrderByDescending(m => m.Created).ToList<ActivityModel>();
        }

        private IList<ActivityGroupModel> Group(IList<ActivityModel> activities)
        {
            var groups = new Dictionary<string, ActivityGroupModel>();
            
            foreach (var activity in activities)
            {
                string key = activity.Created.Date.ToShortDateString();
                if (groups.ContainsKey(key) == false)
                {
                    var group = new ActivityGroupModel();
                    group.Created = activity.Created.Date;
                    group.Activities = new List<ActivityModel>();
                    groups.Add(key, group);
                }

                groups[key].Activities.Add(activity);
            }

            return groups.Values.ToList();
        }
    }
}
