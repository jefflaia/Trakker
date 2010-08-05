using System;
using Trakker.Data;
using System.Collections.Generic;


namespace Trakker.ViewData.ProjectData
{
    public class CreateEditProjectViewData
    {
        public Project Project { get; set; }
        public IList<User> Users { get; set; }

    }
}