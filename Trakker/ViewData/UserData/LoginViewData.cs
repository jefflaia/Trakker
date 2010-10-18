using System;
using System.Web.Mvc;
using Trakker.Data;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using Trakker.Helpers;
using Trakker.ViewData.SharedData;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Trakker.ViewData.UserData
{
    public class LoginViewData : MasterViewData
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must enter your password")]
        public string Password { get; set; }
    }
}
