using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Trakker.Helpers.Elements
{
    public class ButtonElement : IElement
    {
        public TagBuilder Get()
        {
            return new TagBuilder("button");
        }
    }
}