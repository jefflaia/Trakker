using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public class ProjectVersion : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime? ReleaseDate { get; set; }
        public virtual int ProjectId { get; set; }
        public virtual bool IsReleased { get; set; }
        public virtual int SortOrder { get; set; }


        public virtual Project Project { get; set; }
    }
}
