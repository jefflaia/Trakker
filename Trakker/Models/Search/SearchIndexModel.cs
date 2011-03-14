using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trakker.Data;

namespace Trakker.Models.Search
{
    public class SearchIndexModel : MasterModel
    {
        public IList<Ticket> Tickets { get; set; }
    }
}