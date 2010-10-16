using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trakker.Data;
using Trakker.ViewData.SharedData;

namespace Trakker.ViewData.TicketData
{
    public class CommentCreateEditViewData : MasterViewData
    {
        public Comment Comment { get; set; }
    }
}
