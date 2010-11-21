namespace Trakker.Areas.Admin.Models.Management
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Trakker.Data;
    using Trakker.Helpers;
    using Trakker.Models;

    public class AllProjectsModel : MasterModel
    {
        public IList<Project> Projects { get; set; }

    }
}
