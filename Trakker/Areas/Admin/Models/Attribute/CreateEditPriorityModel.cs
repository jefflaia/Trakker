namespace Trakker.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using Trakker.Properties;
    using Trakker.Models;
    using Trakker.Data;

    public class CreateEditPriorityModel : MasterModel
    {
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(50, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength_50")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(250, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength_250")]
        public string Description { get; set; }

        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(6, MinimumLength = 3, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength_HexColor")]
        public string HexColor { get; set; }

        public IList<TicketPriority> Priorities { get; set; }
    }
}