﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trakker.Data;
using Trakker.Helpers;

namespace Trakker.Models
{
    public class TicketDetailsModel : MasterModel
    {
        public int Id { get; set; }
        public string Summary { get; set; }
        public Category Cateogory { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public string KeyName { get; set; }
        public Resolution Resolution { get; set; }
        public Boolean IsClosed { get; set; }

        public User CreatedBy { get; set; }
        public User AssignedBy { get; set; }
        public User AssignedTo { get; set; }


        public IList<Comment> Comments { get; set; }
    }
}