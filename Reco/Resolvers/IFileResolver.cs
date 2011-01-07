using System.Collections.Generic;

namespace Reco.FileResolvers
{
    public interface IFileResolver
    {        
        string Resolve(string file);
    }
}