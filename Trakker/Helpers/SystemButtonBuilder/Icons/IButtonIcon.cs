using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Trakker.Helpers.Icons
{
    public interface IIcon
    {
        TagBuilder Get();
        void SetPositionClass(string cssClass);
    }


}
