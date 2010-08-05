using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trakker.Data;
using Trakker.Services;
using Trakker.Helpers;

namespace Trakker.ViewData.TicketData
{
    public class TicketListViewData
    {
        //public IList<WidgetAction> RowItems { get; set; }


        public WidgetAction Pagination { get; set; }

        public IList<Ticket> Items { get; set; }
        public IDictionary<int, User> Users { get; set; }
        public IDictionary<int, Category> Categories { get; set; }
        public IDictionary<int, Severity> Severities { get; set; }
        public IDictionary<int, Priority> Priorities { get; set; }
        public IDictionary<int, Status> Status { get; set; }
              
                
    }
}
