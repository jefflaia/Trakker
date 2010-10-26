namespace Trakker.ViewData.TicketData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Trakker.ViewData.SharedData;

    public class CreateEditPriorityViewData : MasterViewData
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}