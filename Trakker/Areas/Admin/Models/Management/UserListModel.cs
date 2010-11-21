﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trakker.Data;
using Trakker.Models;

namespace Trakker.Areas.Admin.Models
{
    public class UserListModel : MasterModel
    {
        public IList<User> Users { get; set; }
        public int TotalUsers { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public IDictionary<int, Role> Roles { get; set; }
    }
}