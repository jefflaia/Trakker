using System;
using System.Web.Mvc;
using Trakker.Data;
using System.Collections.Generic;

namespace Trakker.Models.User
{

    public class LogoutModel : MasterModel
    {
        public string Email { get; set; }
    }
}
