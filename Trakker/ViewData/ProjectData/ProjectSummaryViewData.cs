namespace Trakker.ViewData.ProjectData
{
    using Trakker.ViewData.SharedData;
    using Trakker.Data;
    using System.Collections.Generic;

    public class ProjectSummaryViewData : MasterViewData
    {
        public Project Project { get; set; }
        public User Lead { get; set; }
        public IList<Ticket> NewestTickets { get; set; }
        
    }
}
