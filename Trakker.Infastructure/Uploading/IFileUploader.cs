using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Trakker.Infastructure
{
    public interface IFileUploader
    {
        void Upload();
        IList<File> Files{ get; set; }
    }
}
