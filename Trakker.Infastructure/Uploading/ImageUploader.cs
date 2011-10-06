using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Drawing;

namespace Trakker.Infastructure.Uploading
{
    public class ImageUploader : IFileUploader
    {
        private IImageProfile _profile;

        public ImageUploader(IImageProfile profile)
        {
            _profile = profile;
        }

        public virtual void Upload(HttpPostedFileBase file, string destinationPath)
        {
            string filename = Path.Combine(destinationPath, file.FileName);
            file.SaveAs(filename);

            Image image = Image.FromFile(filename);
            Image.GetThumbnailImageAbort dummyCallBack = new Image.GetThumbnailImageAbort(ThumbnailCallback);

            Image newImage = image.GetThumbnailImage(_profile.Icon.Width, _profile.Icon.Height, dummyCallBack, IntPtr.Zero);
            newImage.Save(Path.Combine(destinationPath, _profile.Icon.Prefix + file.FileName));
            newImage.Dispose();

            newImage = image.GetThumbnailImage(_profile.Thumbnail.Width, _profile.Thumbnail.Height, dummyCallBack, IntPtr.Zero);
            newImage.Save(Path.Combine(destinationPath, _profile.Thumbnail.Prefix + file.FileName));
            newImage.Dispose();

            newImage = image.GetThumbnailImage(_profile.Large.Width, _profile.Large.Height, dummyCallBack, IntPtr.Zero);
            newImage.Save(Path.Combine(destinationPath, _profile.Large.Prefix + file.FileName));
            newImage.Dispose();

            image.Dispose();

            if (_profile.KeepOriginal == false)
            {
                File.Delete(filename);   
            }
        }

        private bool ThumbnailCallback()
        {
            return false;
        }
    }
}
