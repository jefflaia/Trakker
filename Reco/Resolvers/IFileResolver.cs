using System.Collections.Generic;

namespace ResourceCompiler.FileResolvers
{
    public interface IFileResolver
    {        
        string Resolve(string file);
    }
}