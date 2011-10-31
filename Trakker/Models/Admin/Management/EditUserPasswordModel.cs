using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foolproof;
using System.ComponentModel;
using Trakker.Data;
using Trakker.Infastructure.Validation;

namespace Trakker.Models.Admin.Management
{
    public class EditUserPasswordModel : MasterModel
    {
        [DisplayName("New Password")]
        [Password]
        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [DisplayName("Confirm New Password")]
        [Password]
        [EqualTo("Password", ErrorMessageResourceType = typeof(Trakker.Infastructure.Resources.Validation), ErrorMessageResourceName = "PasswordsMustMatch")]
        [Required]
        [StringLength(100)]
        public string RePassword { get; set; }

        public Trakker.Data.User User { get; set; }
    }
}
