namespace Trakker.Models
{
    using Trakker.Data;
    using System.Collections.Generic;

    public class ProjectOverviewTabModel : MasterModel
    {
        public Project Project { get; set; }
        public User Lead { get; set; }
        public IList<Ticket> NewestTickets { get; set; }
        
    }
}
