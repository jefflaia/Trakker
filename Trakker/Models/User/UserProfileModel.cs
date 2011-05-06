using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trakker.Data;
using Trakker.Infastructure.Streams.Activity.Model;

namespace Trakker.Models
{
    public class UserProfileModel : MasterModel
    {
        public User User { get; set; }
        public IList<ActivityGroupModel> ActivityStreamGroups { get; set; }

        public bool IsOwner { get; set; }
    }
}