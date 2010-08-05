using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Trakker.Helpers.Elements
{
    public interface IElement
    {
        TagBuilder Get();
    }
}
