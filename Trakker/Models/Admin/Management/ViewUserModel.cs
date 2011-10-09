using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trakker.Models;
using Trakker.Data;

namespace Trakker.Models.Admin.Management
{
    public class ViewUserModel : MasterModel
    {
        public User User { get; set; }
    }
}