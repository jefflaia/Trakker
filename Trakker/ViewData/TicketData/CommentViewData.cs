using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trakker.Data;
using Trakker.Data.Services;
using Trakker.ViewData.SharedData;

namespace Trakker.ViewData.TicketData
{
    public class CommentViewData : MasterViewData
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public int ticketId { get; set; }

    }
}
