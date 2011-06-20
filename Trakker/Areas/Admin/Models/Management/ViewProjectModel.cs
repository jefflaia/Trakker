using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trakker.Models;
using Trakker.Data;

namespace Trakker.Areas.Admin.Models
{
    public class ViewProjectModel : MasterModel
    {
        public Project Project { get; set; }
        public ColorPalette Palette { get; set; }
        public User User { get; set; }
    }
}