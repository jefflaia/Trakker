using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trakker.Data;
using Trakker.Infastructure.Validation;

namespace Trakker.Models.Admin.Management
{
    public class ReleaseVersionModel : MasterModel
    {
        [Date]
        public DateTime? ReleaseDate { get; set; }

        public Data.Project Project { get; set; }
        public ProjectVersion Version { get; set; }
        public int NumberOfTicketsOpen { get; set; }
    }
}