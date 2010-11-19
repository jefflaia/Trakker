namespace Trakker.Areas.Admin.Models.Management
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Trakker.Data;
    using Trakker.Helpers;
    using Trakker.ViewData.SharedData;

    public class AllProjectsModel : MasterViewData
    {
        public IList<Project> Projects { get; set; }

    }
}
