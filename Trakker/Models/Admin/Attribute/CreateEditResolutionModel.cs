
namespace Trakker.Models.Admin.Attribute
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Trakker.Models;
    using Trakker.Data;
    using Trakker.Infastructure.Validation;

    public class CreateEditResolutionModel : MasterModel
    {
        [Required()]
        [StringLength(50)]
        public string Name { get; set; }

        [Required()]
        [StringLength(250)]
        public string Description { get; set; }

        public IList<TicketResolution> Resolutions { get; set; }
    }
}