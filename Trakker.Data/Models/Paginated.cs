using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public class Paginated<T>
    {
        public IList<T> Items { get; set; }
        public int TotalItems { get; set; }
        public int Index { get; set; }
    }
}
