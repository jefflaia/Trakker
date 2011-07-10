using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Data;

namespace Trakker.Infastructure
{
    public class UploadManager
    {
        IPathResolver _pathResolver;
        IFileUploader _fileUploader;

        public UploadManager(IPathResolver pathResolver, IFileUploader fileUploader) 
        {
            _pathResolver = pathResolver;
            _fileUploader = fileUploader;
        }

        public void Upload()
        {
            if (_pathResolver.PathExists() == false)
            {
                _pathResolver.CreatePath();
            }


            _fileUploader.Upload(_pathResolver.ResolvePath());
        }

        #region Private Members

        #endregion

    }
}
