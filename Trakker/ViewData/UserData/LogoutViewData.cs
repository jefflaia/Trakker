using System;
using System.Web.Mvc;
using Trakker.Data;
using System.Collections.Generic;
using Trakker.ViewData.SharedData;

namespace Trakker.ViewData.UserData
{

    public class LogoutViewData : MasterViewData
    {
        public string Email { get; set; }
    }
}
