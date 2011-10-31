using System;
using System.Web.Mvc;
using Trakker.Data;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using Trakker.Helpers;
using System.ComponentModel;
using Trakker.Infastructure.Validation;


namespace Trakker.Models.User
{
    public class LoginModel : MasterModel
    {
        [Email]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
