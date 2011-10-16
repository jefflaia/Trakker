using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trakker.Models;
using Trakker.Data;

namespace Trakker.Models.Admin.Management
{
    public class ViewProjectModel : MasterModel
    {
        public Trakker.Data.Project Project { get; set; }
        public ColorPalette Palette { get; set; }
        public Trakker.Data.User User { get; set; }
        public IList<ProjectVersion> Versions { get; set; }
    }
}