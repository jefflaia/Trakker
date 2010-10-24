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

    public class CreateEditUserViewData : MasterViewData
    {
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(100, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength_100")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(100, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength_100")]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(100, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength_100")]
        public string RePassword { get; set; }

        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public int RoleId { get; set; }
        public IList<Role> Roles { get; set; }
    }

}