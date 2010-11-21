using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trakker.ViewData.SharedData;
using Trakker.Data;

namespace Trakker.Areas.Admin.Models.Management
{
    public class UserListModel : MasterViewData
    {
        public IList<User> Users { get; set; }
        public int TotalUsers { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public IDictionary<int, Role> Roles { get; set; }
    }
}