using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trakker.Data;
using Trakker.Data;
using Trakker.Infastructure.Validation;

namespace Trakker.Models.Admin.Management
{
    public class ManageVersionsModel : MasterModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [Date]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        public int AfterVersionId { get; set; }


        public Data.Project Project { get; set; }
        public IList<ProjectVersion> Versions { get; set; }
    }
}