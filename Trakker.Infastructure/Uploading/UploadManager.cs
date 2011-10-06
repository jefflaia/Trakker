using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Data;
using System.Web;

namespace Trakker.Infastructure.Uploading
{
    public class UploadManager
    {
        IPathResolver _pathResolver;
        IFileUploader _fileUploader;
        IList<HttpPostedFileBase> _files;

        public UploadManager(HttpRequestBase request, IPathResolver pathResolver, IFileUploader fileUploader) 
        {
            _pathResolver = pathResolver;
            _fileUploader = fileUploader;
            _files = GetPostedFiles(request);
        }

        public void Upload()
        {
            if (_pathResolver.PathExists() == false)
            {
                _pathResolver.CreatePath();
            }

            foreach (var file in _files)
            {
                _fileUploader.Upload(file, _pathResolver.ResolvePath());
            }
        }


        #region Private Members
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
