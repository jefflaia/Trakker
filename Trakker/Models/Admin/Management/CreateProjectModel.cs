namespace Trakker.Models.Admin.Management
{
    using System;
    using Trakker.Data;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Trakker.Infastructure.Validation;


    public class CreateProjectModel : EditProjectModel
    {
        [DisplayName("Key")]
        [Required()]
        [StringLength(20)]
        public string KeyName { get; set; }

    }
}