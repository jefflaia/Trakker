using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.UI;
using System.IO;
using System.Web;

namespace Trakker.Infastructure.UI
{
    public abstract class ViewComponentBase : IAttributesContainer
    {
        protected ViewComponentBase(IAssetManager assetManager)
        {
            AssetManager = assetManager;

            HtmlAttributes = new Dictionary<string, object>();
        }

        public IAssetManager AssetManager 
        { 
            get; 
            private set; 
        }

        public IDictionary<string, object> HtmlAttributes
        {
            get;
            private set;
        }

    }
}
