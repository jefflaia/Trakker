namespace Trakker.Models.Admin.Management
{
    using Trakker.Data;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Trakker.Properties;
    using Foolproof;
    using Trakker.Models;

    public class EditUserModel : MasterModel
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

        [DisplayName("Role")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public int RoleId { get; set; }
        
        public IList<Role> Roles { get; set; }
    }

}