using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;

namespace Trakker.Infastructure
{
    public class FileUploader : IFileUploader
    {
        private string _path;
        private IList<HttpPostedFileBase> _postedFiles;


        public IList<File> Files { get; set; }

        public FileUploader(HttpRequestBase request, IPathResolver pathResolver)
        {
            _path = pathResolver.ResolvePath(); ;
            _postedFiles = GetPostedFiles(request);
            Files = new List<File>();
        }

        public virtual void Upload()
        {
            foreach (HttpPostedFileBase postedFile in _postedFiles)
            {
                string filename = GenerateFileName(postedFile.FileName);
                postedFile.SaveAs(filename);
                AddFile(postedFile);
            }
        }

        #region Private Members
        private string GenerateFileName(string postedFileName)
        {
            return Path.Combine(
                   _path,
                   Path.GetFileName(postedFileName));
        }

        private void AddFile(HttpPostedFileBase postedFile)
        {
            Files.Add(new File
            {
                Name = Path.GetFileName(postedFile.FileName),
                Ext = Path.GetExtension(postedFile.FileName),
                Path = Path.GetFullPath(postedFile.FileName),
                ContentType = postedFile.ContentType,
                ContentLength = postedFile.ContentLength,
            });
        }

        private IList<HttpPostedFileBase> GetPostedFiles(HttpRequestBase request)
        {
            IList<HttpPostedFileBase> files = new List<HttpPostedFileBase>();


            foreach (string file in request.Files)
            {
                HttpPostedFileBase hpf = request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength == 0)
                {
                    continue;
                }

                files.Add(hpf);
            }

            return files;
        }
        #endregion
    }
}
