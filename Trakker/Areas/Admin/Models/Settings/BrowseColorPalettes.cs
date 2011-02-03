using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trakker.Models;
using Trakker.Data;

namespace Trakker.Areas.Admin.Models
{
    public class BrowseColorPalettes : MasterModel
    {
        public IList<ColorPalette> ColorPalettes { get; set; }

    }
}