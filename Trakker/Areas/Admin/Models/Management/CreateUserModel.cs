namespace Trakker.Areas.Admin.Models
{
    using Trakker.Data;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Trakker.Properties;
    using Foolproof;
    using Trakker.Models;

    public class CreateUserModel : EditUserModel
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(100, MinimumLength = 8, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "PasswordLength")]
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [EqualTo("Password", ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "PasswordsMustMatch")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(100, MinimumLength = 8, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "PasswordLength")]
        public string RePassword { get; set; }
        
    }

}