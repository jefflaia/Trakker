using System;
using Trakker.Data;
using System.Collections.Generic;
using Trakker.ViewData.SharedData;
using System.ComponentModel.DataAnnotations;
using Trakker.Properties;
using System.ComponentModel;


namespace Trakker.ViewData.ProjectData
{
    public class CreateProjectViewData : EditProjectViewData
    {
        [DisplayName("Key")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(20, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength_20")]
        public string KeyName { get; set; }

    }
}