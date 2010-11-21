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


namespace Trakker.Models
{
    public class LoginModel : MasterModel
    {
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public string Password { get; set; }
    }
}
