using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trakker.Data;
using System.ComponentModel.DataAnnotations;
using Trakker.Properties;

namespace Trakker.Models.Admin.Management
{
    public class ManageVersionsModel : MasterModel
    {
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(50, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength_50")]
        public string Name { get; set; }

        [StringLength(50, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength_50")]
        public string Description { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public int AfterVersionId { get; set; }


        public IList<ProjectVersion> Versions { get; set; }
    }
}