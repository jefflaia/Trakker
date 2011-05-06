using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using ResourceCompiler;
using ResourceCompiler.Compressors.StyleSheet;
using ResourceCompiler.Compressors.JavaScript;

namespace Trakker.Bootstrap
{
    public class RegisterAssets : IBootstrapperTask
    {

        public void Execute()
        {
            RecoAssets.StyleSheet()
                .Add("~/Content/Reset.css")
                .Add("~/Content/Main.css")
                .Add("~/Content/Project.css")
                .Add("~/Content/Admin/Settings.css")
                .Add("~/Content/Ticket.css")
                .Add("~/Content/User.css")
                .AddDynamic("~/Content/Theme.css")
                .Media(MediaType.Screen)
                .Combine(true)
                .Compress(true)
                .Version(true)
                .SetCompressor(new YuiCompressor());

            RecoAssets.JavaScript()
                .Add("~/Scripts/jquery-1.4.1.js")
                .Add("~/Scripts/jqueryTools.tabs.js")
                .Combine(true)
                .Compress(true)
                .Version(true)
                .SetCompressor(new YuiMinifier());
        }
    }
}