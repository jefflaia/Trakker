using System;
using System.Web.Mvc;
using Trakker.Data;
using System.Collections.Generic;
using System.ComponentModel;
using Trakker.ViewData.SharedData;

namespace Trakker.ViewData.UserData
{

    public class CreateEditUserViewData : MasterViewData
    {
        [DisplayName("Email")]
        [Description("Demonstrates DisplayNameAttribute.")]
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public int RoleId { get; set; }
        public IList<Role> Roles { get; set; }
    }

}