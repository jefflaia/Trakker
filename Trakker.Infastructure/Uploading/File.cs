using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Infastructure
{
    public class File
    {
        public string Name { get; set; }
        public string Ext { get; set; }
        public string Path { get; set; }
        public string ContentType { get; set; }
        public Int64 ContentLength { get; set; }
        public DateTime Uploaded { get; set; }

        public string Source()
        {
            return String.Concat(Path, Name, ".", Ext);
        }
        
    }
}
