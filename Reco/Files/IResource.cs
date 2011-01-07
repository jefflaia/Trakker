using System;
namespace Reco.Files
{
    public interface IResource
    {
        string FilePath { get; }
        string FileType { get; }
        string GetContents();
        bool Exists();
        DateTime GetLastWrite();
    }
}
