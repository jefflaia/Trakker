using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Trakker.Properties;
using Trakker.Models;

namespace Trakker.Models.Admin.Settings
{
    public class CreateEditColorPaletteModel : MasterModel
    {

        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(50, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength_50")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(6, MinimumLength = 3, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength_HexColor")]
        public string NavBackgroundColor { get; set; }

        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(6, MinimumLength = 3, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength_HexColor")]
        public string SubNavBackgroundColor { get; set; }

        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(6, MinimumLength = 3, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength_HexColor")]
        public string HighlightColor { get; set; }

        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(6, MinimumLength = 3, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength_HexColor")]
        public string NavTextColor { get; set; }

        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(6, MinimumLength = 3, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength_HexColor")]
        public string SubNavTextColor { get; set; }

        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(6, MinimumLength = 3, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength_HexColor")]
        public string LinkColor { get; set; }
    }
}