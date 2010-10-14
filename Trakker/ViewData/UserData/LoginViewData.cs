using System;
using System.Web.Mvc;
using Trakker.Data;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using Trakker.Helpers;
using Trakker.ViewData.SharedData;

namespace Trakker.ViewData.UserData
{

    public class LoginViewData : MasterViewData
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
