using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trakker.Models;
using Trakker.Infastructure.Validation;

namespace Trakker.Models.Admin.Settings
{
    public class CreateEditColorPaletteModel : MasterModel
    {

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [HexColor]
        public string NavBackgroundColor { get; set; }

        [Required]
        [HexColor]
        public string SubNavBackgroundColor { get; set; }

        [Required]
        [HexColor]
        public string HighlightColor { get; set; }

        [Required]
        [HexColor]
        public string NavTextColor { get; set; }

        [Required]
        [HexColor]
        public string SubNavTextColor { get; set; }

        [Required]
        [HexColor]
        public string LinkColor { get; set; }
    }
}