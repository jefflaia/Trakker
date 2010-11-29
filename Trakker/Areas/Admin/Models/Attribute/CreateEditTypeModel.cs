
namespace Trakker.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Trakker.Models;
    using System.ComponentModel.DataAnnotations;
    using Trakker.Properties;
    using Trakker.Data;


    public class CreateEditTypeModel : MasterModel
    {
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(50, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength_50")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(250, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength_250")]
        public string Description { get; set; }

        public IList<TicketType> Types { get; set; }
    }
}