using System;
using System.Web.Mvc;
using Trakker.Data;
using System.Collections.Generic;

namespace Trakker.ViewData.UserData
{

    public class CreateUserViewData
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }

}