using System;
using System.Web.Mvc;
using Trakker.Data;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using Trakker.Helpers;

namespace Trakker.ViewData.UserData
{

    public class LoginViewData
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public HtmlTableBuilder<User> Table { get; set; }
    }
}
