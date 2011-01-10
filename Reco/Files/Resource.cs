
namespace ResourceCompiler.Files
{
    using System.IO;
    using System;

    public class Resource : IResource
    {
        protected IFileReader _reader;

        public string FilePath { get; private set; }
        public string FileType { get; private set; }

        public Resource(string filePath, string fileType)
        {
            FilePath = filePath;
            FileType = fileType;
            _reader = new FileReader(filePath);
        }

        public Resource(string filePath, string fileType, IFileReader reader)
        {
            FilePath = filePath;
            FileType = fileType;
            _reader = reader;
        }

        public string GetContents()
        {
            return _reader.ReadToEnd();
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