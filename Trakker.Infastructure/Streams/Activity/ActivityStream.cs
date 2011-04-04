using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Data.Services;
using Trakker.Data;
using Trakker.Infastructure.Streams.Activity.Model;

namespace Trakker.Core.Streams.Activity
{
    abstract public class ActivityStream
    {
        private IUserService _userService;

        public ActivityStream(IUserService userService)
        {
            _userService = userService;
            
        }

        abstract IList<Comment> GetComment(int step, int take);

        abstract IList<ActivityModel> MapComment(Comment comment);

        protected IDictionary<int, User> GetUsers(int[] ids)
        {
            var users = new Dictionary<int, User>();

            foreach (int id in ids)
            {
                users.Add(id, _userService.GetUserWithId(id));
            }

            return users;
        }


        private void Sort(IList<ActivityModel> activities)
        {
            activities.OrderBy(m => m.Created).Reverse().ToList<ActivityModel>();
        }

        private IList<ActivityGroupModel> Group(IList<ActivityModel> activities)
        {
            Sort(activities);

            DateTime max = activities.Max(m => m.Created);
            DateTime min = activities.Min(m => m.Created);
            var groups = new Dictionary<DateTime, ActivityGroupModel>();

            //create a new group model for each day from min to max
            while (min < max)
            {
                var group = new ActivityGroupModel();
                group.Created = min;
                groups.Add(min.Date, group);

                min.AddDays(1);
            }

            //add activities based on the date to the respected group
            DateTime previous = activities.Min(m => m.Created).Date;
            foreach (var activity in activities)
            {
                groups[activity.Created.Date].Activities.Add(activity);
            }

            return groups.Values.ToList();
        }

        public virtual IList<ActivityGroupModel> Generate()
        {

        }
    }
}
