
namespace ResourceCompiler.Files
{
    using System.IO;
    using System;

    public class Resource : IResource
    {
        public string FilePath { get; private set; }
        public string FileType { get; private set; }

        public Resource(string filePath, string fileType)
        {
            FilePath = filePath;
            FileType = fileType;
        }

        public bool Exists()
        {
            return File.Exists(FilePath);
        }

        public DateTime GetLastWrite()
        {
            string fileName = FilePath;
            DateTime lastWriteDateTime = DateTime.MinValue;
            try
            {
                if (fileName.StartsWith("~"))
                {
                    fileName = fileName.Remove(0);
                    fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                }
                lastWriteDateTime = File.GetLastWriteTime(fileName);
            }
            catch { }

            return lastWriteDateTime;
        }
    }
}