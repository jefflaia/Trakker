using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Foolproof;
using System.ComponentModel;
using Trakker.Properties;
using Trakker.Models;
using Trakker.Data;

namespace Trakker.Areas.Admin.Models
{
    public class EditUserPasswordModel : MasterModel
    {
        [DisplayName("New Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(100, MinimumLength = 8, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "PasswordLength")]
        public string Password { get; set; }

        [DisplayName("Confirm New Password")]
        [DataType(DataType.Password)]
        [EqualTo("Password", ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "PasswordsMustMatch")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(100, MinimumLength = 8, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "PasswordLength")]
        public string RePassword { get; set; }

        public User User { get; set; }
    }
}
