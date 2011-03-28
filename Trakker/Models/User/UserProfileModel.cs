﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trakker.Data;
using ActivityStream.Model;

namespace Trakker.Models
{
    public class UserProfileModel : MasterModel
    {
        public User User { get; set; }
        public IList<ActivityGroupModel> ActivityStreamGroups { get; set; }
    }
}