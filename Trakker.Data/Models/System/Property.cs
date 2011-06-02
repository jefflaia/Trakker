using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public class Property<T>
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public T Value { get; set; }
        public string Type { get; set; }
        public DateTime Created { get; set; }
    }
}
