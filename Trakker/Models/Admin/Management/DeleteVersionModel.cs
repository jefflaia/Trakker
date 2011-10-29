using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Trakker.Properties;

namespace Trakker.Models.Admin.Management
{
    public class DeleteVersionModel : MasterModel
    {
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public int VersionId { get; set; }

        public int NumberOfTicketsToBeFixed { get; set; }
        public int NumberOfTicketsFound { get; set; }

        public Data.Project Project { get; set; }
        public Data.ProjectVersion Version { get; set; }
        public IList<Data.ProjectVersion> Versions { get; set; }
    }
}