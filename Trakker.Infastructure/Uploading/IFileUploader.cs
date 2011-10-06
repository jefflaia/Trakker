using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace Trakker.Infastructure.Uploading
{
    public interface IFileUploader
    {
        void Upload(HttpPostedFileBase file, string destinationPath);

    }
}
