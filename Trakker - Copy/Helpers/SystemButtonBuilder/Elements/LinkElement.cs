using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Trakker.Helpers.Elements
{
    public class LinkElement : IElement
    {
        public TagBuilder Get()
        {
            return new TagBuilder("a");
        }
    }
}