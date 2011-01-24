using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResourceCompiler.Renderers
{
    public interface IJavaScriptRenderer
    {
        string Generate();
    }
}
