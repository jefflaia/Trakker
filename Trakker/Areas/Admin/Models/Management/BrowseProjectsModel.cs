namespace Trakker.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Trakker.Data;
    using Trakker.Helpers;
    using Trakker.Models;

    public class BrowseProjectsModel : MasterModel
    {
        public IList<Project> Projects { get; set; }

    }
}
