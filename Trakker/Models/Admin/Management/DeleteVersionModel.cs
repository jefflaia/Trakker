using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trakker.Infastructure.Validation;

namespace Trakker.Models.Admin.Management
{
    public class DeleteVersionModel : MasterModel
    {
        [Required()]
        public int VersionId { get; set; }

        public int NumberOfTicketsToBeFixed { get; set; }
        public int NumberOfTicketsFound { get; set; }

        public Data.Project Project { get; set; }
        public Data.ProjectVersion Version { get; set; }
        public IList<Data.ProjectVersion> Versions { get; set; }
    }
}