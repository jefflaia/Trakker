using System;
using System.Web.Mvc;
using Trakker.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Trakker.Properties;
using System.ComponentModel;

namespace Trakker.Models.Ticket
{

    public class CreateEditTicketModel : MasterModel
    {
        [DisplayName("Project")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public int ProjectId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(100, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength_100")]
        public string Summary { get; set; }

        [DisplayName("Assigned To")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public int AssignedToUserId { get; set; }

        [DisplayName("Priority")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public int PriorityId { get; set; }

        [DisplayName("Status")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public int StatusId { get; set; }

        [DisplayName("Category")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public int CategoryId { get; set; }

        [DisplayName("Resolution")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public int ResolutionId { get; set; }

        [DisplayName("Due Date")]
        public DateTime? DueDate { get; set; }

        public string Description { get; set; }
        public string KeyName { get; set; }

        public IList<TicketPriority> Priorities { get; set; }
        public IList<TicketType> Categories { get; set; }
        public IList<TicketStatus> Status { get; set; }
        public IList<Trakker.Data.Project> Projects { get; set; }
        public IList<TicketResolution> Resolutions { get; set; }
        public IList<Trakker.Data.User> Users { get; set; }

    }
}
