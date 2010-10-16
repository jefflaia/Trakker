using System;
using Trakker.Data;
using System.Collections.Generic;
using Trakker.ViewData.SharedData;


namespace Trakker.ViewData.ProjectData
{
    public class CreateEditProjectViewData : MasterViewData
    {
        public Project Project { get; set; }
        public IList<User> Users { get; set; }

    }
}