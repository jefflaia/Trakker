namespace Trakker.Models
{
    using Trakker.Data;
    using System.Collections.Generic;

    public class ProjectRoadMapTabModel : MasterModel
    {
        public IList<ProjectVersion> Versions { get; set; }
        public Trakker.Data.Project Project { get; set; }
    }
}
