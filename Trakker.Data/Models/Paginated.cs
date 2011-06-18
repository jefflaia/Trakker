using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public class Paginated<T>
    {
        public virtual IList<T> Items { get; set; }
        public virtual int TotalItems { get; set; }
        public virtual int Index { get; set; }
    }
}
