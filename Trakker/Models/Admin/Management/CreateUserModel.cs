namespace Trakker.Models.Admin.Management
{
    using Trakker.Data;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Foolproof;
    using Trakker.Models;
    using Trakker.Infastructure.Validation;

    public class CreateUserModel : EditUserModel
    {
        [Password]
        [Required()]
        [StringLength(100)]
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [Password]
        [EqualTo("Password", ErrorMessageResourceType = typeof(Trakker.Infastructure.Resources.Validation), ErrorMessageResourceName = "PasswordsMustMatch")]
        [Required()]
        [StringLength(100)]
        public string RePassword { get; set; }
        
    }

}