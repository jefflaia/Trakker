namespace Trakker.Models.Admin.Management
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel;
    using Trakker.Data;
    using Trakker.Models;
    using Trakker.Core;
    using Trakker.Infastructure.Validation;

    public class EditProjectModel : MasterModel
    {
        [Required()]
        [StringLength(100)]
        public string Name { get; set; }

        [Required()]
        [StringLength(100)]
        [Uri()]
        public string Url { get; set; }

        [DisplayName("Due Date")]
        [Required()]
        public DateTime? Due { get; set; }

        [Required()]
        public int Lead { get; set; }

        [DisplayName("Color Palette")]
        [Required()]
        public int ColorPaletteId { get; set; }

        public IList<User> Users { get; set; }
        public IList<ColorPalette> ColorPalettes { get; set; }

    }
}