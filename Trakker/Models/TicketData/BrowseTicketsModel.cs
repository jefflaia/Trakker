using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trakker.Data;
using Trakker.Data.Services;
using Trakker.Helpers;

namespace Trakker.Models
{
    public class BrowseTicketsModel : MasterModel
    {
        public IList<Ticket> Items { get; set; }
        public int TotalTickets { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public IDictionary<int, User> Users { get; set; }
        public IDictionary<int, Category> Categories { get; set; }
        public IDictionary<int, Priority> Priorities { get; set; }
        public IDictionary<int, Status> Status { get; set; }
              
                
    }
}
