using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public class BaseEntity : IBaseEntity
    {
        public virtual int Id { get; set; }
    }
}
