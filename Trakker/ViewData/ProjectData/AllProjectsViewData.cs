using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trakker.Data;
using Trakker.Helpers;
using Trakker.ViewData.SharedData;

namespace Trakker.ViewData.ProjectData
{
    public class AllProjectsViewData : MasterViewData
    {
        public IList<Project> Projects { get; set; }

    }
}
