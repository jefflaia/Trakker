using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trakker.Data;
using Trakker.Models;

namespace Trakker.Models.Admin.Management
{
    public class BrowseUsersModel : MasterModel
    {
        public IList<Trakker.Data.User> Users { get; set; }
        public int TotalUsers { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public IDictionary<int, Role> Roles { get; set; }
    }
}