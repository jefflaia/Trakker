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
        private IList<HttpPostedFileBase> _postedFiles;


        public FileUploader(HttpRequestBase request)
        {
            _postedFiles = GetPostedFiles(request);
        }

        public virtual void Upload(string destinationPath)
        {
            foreach (HttpPostedFileBase postedFile in _postedFiles)
            {
                string filename = GenerateFileName(destinationPath, postedFile.FileName);
                postedFile.SaveAs(filename);
            }
        }

        #region Private Members
        private string GenerateFileName(string path, string postedFileName)
        {
            return Path.Combine(path, Path.GetFileName(postedFileName));
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
