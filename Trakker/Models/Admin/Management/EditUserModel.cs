namespace Trakker.Models.Admin.Management
{
    using Trakker.Data;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Foolproof;
    using Trakker.Models;
    using Trakker.Infastructure.Validation;

    public class EditUserModel : MasterModel
    {
        [DisplayName("First Name")]
        [Required()]
        [StringLength(50)]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required()]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required()]
        [StringLength(100)]
        [Email()]
        public string Email { get; set; }

        [DisplayName("Role")]
        [Required()]
        public int RoleId { get; set; }
        
        public IList<Role> Roles { get; set; }
    }

}