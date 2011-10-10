using System;
using System.Web.Mvc;
using Trakker.Data;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using Trakker.Helpers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Trakker.Properties;


namespace Trakker.Models.User
{
    public class LoginModel : MasterModel
    {
        [Email(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Email")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public string Password { get; set; }
    }
}
