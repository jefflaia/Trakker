using System;
namespace ResourceCompiler.Files
{
    public interface IResource
    {
        string FilePath { get; }
        string FileType { get; }
        bool Exists();
        DateTime GetLastWrite();
    }
}
