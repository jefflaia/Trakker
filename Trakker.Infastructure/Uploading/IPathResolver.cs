using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Infastructure
{
    public interface IPathResolver
    {
        string ResolvePath();
        bool PathExists();
        void CreatePath();
    }
}
