namespace Trakker.Models
{
    using Trakker.Data;
    using System.Collections.Generic;

    public class ProjectOverviewTabModel : MasterModel
    {
        public Trakker.Data.Project Project { get; set; }
        public Trakker.Data.User Lead { get; set; }
        public IList<Trakker.Data.Ticket> NewestTickets { get; set; }
        
    }
}
