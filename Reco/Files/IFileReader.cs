using System;

namespace Reco.Files
{
    public interface IFileReader: IDisposable
    {
        string ReadLine();
        string ReadToEnd();
    }
}