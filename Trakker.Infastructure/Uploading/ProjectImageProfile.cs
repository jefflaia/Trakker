using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Infastructure.Uploading
{
    public class ProjectImageProfile : IImageProfile
    {

        public string Identifier
        {
            get 
            { 
                return "project-avatar"; 
            }
        }

        public ImageProperties Icon
        {
            get 
            {
                return new ImageProperties
                {
                    Width = 16,
                    Height = 16,
                    Prefix = "icon-"
                };                
            }
        }

        public ImageProperties Thumbnail
        {
            get
            {
                return new ImageProperties
                {
                    Width = 42,
                    Height = 42,
                    Prefix = "thumbnail-"
                };
            }
        }

        public ImageProperties Large
        {
            get 
            {
                return new ImageProperties
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
