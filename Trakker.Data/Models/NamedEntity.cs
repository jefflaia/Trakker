using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public class NamedEntity : BaseEntity, INamedEntity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}
