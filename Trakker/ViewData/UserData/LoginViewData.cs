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
using Trakker.Properties;


namespace Trakker.ViewData.UserData
{
    public class LoginViewData : MasterViewData
    {
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public string Password { get; set; }
    }
}
