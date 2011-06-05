using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public interface INamedEntity : IBaseEntity
    {
        string Name { get; set; }
        string Description { get; set; }
    }
}
