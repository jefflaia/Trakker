using System;
using System.Web.Mvc;
using Trakker.Data;
using System.Collections.Generic;
using Trakker.ViewData.SharedData;
using System.ComponentModel.DataAnnotations;
using Trakker.Properties;

namespace Trakker.ViewData.TicketData
{

    public class CreateEditViewData : MasterViewData
    {
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public int ProjectId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public string Summary { get; set; }

        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public int AssignedToUserId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public int PriorityId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public int StatusId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public int CategoryId { get; set; }

        public DateTime? DueDate { get; set; }
        public string Description { get; set; }
        public string KeyName { get; set; }

        public IList<Priority> Priorities { get; set; }
        public IList<Category> Categories { get; set; }
        public IList<Status> Status { get; set; }
        public IList<User> Users { get; set; }
        public IList<Project> Projects { get; set; }

    }
}
