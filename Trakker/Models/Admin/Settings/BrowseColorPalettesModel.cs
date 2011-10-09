using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trakker.Models;
using Trakker.Data;

namespace Trakker.Models.Admin.Settings
{
    public class BrowseColorPalettesModel : MasterModel
    {
        public IList<ColorPalette> ColorPalettes { get; set; }
        public ColorPalette SelectedColorPalette { get; set; }

    }
}