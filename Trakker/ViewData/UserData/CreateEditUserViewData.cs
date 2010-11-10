namespace Trakker.ViewData.UserData
{
    using System;
    using System.Web.Mvc;
    using Trakker.Data;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Trakker.ViewData.SharedData;
    using System.ComponentModel.DataAnnotations;
    using Trakker.Properties;
    using Foolproof;

    public class CreateEditUserViewData : MasterViewData
    {
        [DisplayName("First Name")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(50, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength_50")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(50, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength_50")]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(100, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength_100")]
        [Email(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Email")]
        public string Email { get; set; }

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

        [DisplayName("Role")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public int RoleId { get; set; }
        
        public IList<Role> Roles { get; set; }
    }

}