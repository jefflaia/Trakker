namespace Trakker.Models.Admin.Management
{
    using System;
    using Trakker.Data;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Trakker.Properties;
    using System.ComponentModel;


    public class CreateProjectModel : EditProjectModel
    {
        [DisplayName("Key")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(20, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength_20")]
        public string KeyName { get; set; }

    }
}