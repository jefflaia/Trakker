using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Infastructure.Uploading
{
    public class AvatarImageProfile : IImageProfile
    {

        public string Identifier
        {
            get 
            { 
                return "project-avatar"; 
            }
        }

        public ImageAttributes Icon
        {
            get 
            {
                return new ImageAttributes
                {
                    Width = 16,
                    Height = 16,
                    Prefix = "icon-"
                };                
            }
        }

        public ImageAttributes Thumbnail
        {
            get
            {
                return new ImageAttributes
                {
                    Width = 42,
                    Height = 42,
                    Prefix = "thumbnail-"
                };
            }
        }

        public ImageAttributes Large
        {
            get 
            {
                return new ImageAttributes
                {
                    Width = 1000,
                    Height = 1000,
                    Prefix = "large-"
                }; 
            }
        }

        public bool KeepOriginal
        {
            get { return false; }
        }
    }
}
