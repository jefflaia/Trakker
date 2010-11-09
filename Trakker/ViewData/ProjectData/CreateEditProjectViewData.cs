using System;
using Trakker.Data;
using System.Collections.Generic;
using Trakker.ViewData.SharedData;
using System.ComponentModel.DataAnnotations;
using Trakker.Properties;
using System.ComponentModel;


namespace Trakker.ViewData.ProjectData
{
    public class CreateEditProjectViewData : MasterViewData
    {
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(100, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength_100")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(100, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength_100")]
        public string Url { get; set; }

        [DisplayName("Key")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(20, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength_20")]
        public string KeyName { get; set; }

        [DisplayName("Due Date")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public DateTime? Due { get; set; }

        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public int Lead { get; set; }

        public IList<User> Users { get; set; }

    }
}