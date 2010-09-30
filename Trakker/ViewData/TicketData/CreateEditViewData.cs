using System;
using System.Web.Mvc;
using Trakker.Data;
using System.Collections.Generic;

namespace Trakker.ViewData.TicketData
{

    public class CreateEditViewData
    {
        public Ticket Ticket { get; set; }
        public IList<Priority> Priorities { get; set; }
        public IList<Category> Categories { get; set; }
        public IList<Status> Status { get; set; }
        public IList<User> Users { get; set; }
    }
}
