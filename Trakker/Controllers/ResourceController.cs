

namespace Trakker.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Text;
    using System.Web.UI.MobileControls;
    using Telerik.Web.Mvc;
    using Reco;

    //[CompressFilter]
    public class ResourceController : Controller
    {
        

        static ContentResult cr = null;
        public static IList<string> cssFiles;

        public ResourceController()
        {
            cssFiles = new List<string>();
            cssFiles.Add("Main.css");
            cssFiles.Add("Project.css");
            cssFiles.Add("Theme.css");
        }

        //[CacheFilter(Duration = 9999999)]
        public ContentResult CSS(string fileName)
        {

            return new ContentResult() {
                Content = string.Empty
            };
            /*
            try
            {
                if (cr == null)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (string cssFile in cssFiles)
                    {
                        string file = Request.PhysicalApplicationPath + "/Content/" + cssFile;
                        sb.Append(System.IO.File.ReadAllText(file));
                        sb.Append("\n");
                    }

                    //sb.Replace("[IMAGE_URL]", StaticData.Instance.ImageUrl);

                    cr = new ContentResult();
                    cr.Content = sb.ToString();
                    cr.ContentType = "text/css";
                }

                return cr;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError(ex.Message);
                return View();
            }*/
        }


        /**
        string _CssFileName = null;
        public string CssFileName
        {
            get
            {
                if (String.IsNullOrEmpty(_CssFileName))
                {
                    DateTime dt = new DateTime(2000, 1, 1);
                    foreach (string cssFile in Constants.cssFiles)
                    {
                        string file = System.Web.HttpContext.Current.Server.MapPath(cssFile);
                        FileInfo fi = new FileInfo(file);
                        DateTime lastWriteTime = fi.LastWriteTime;
                        if (lastWriteTime > dt)
                        {
                            dt = lastWriteTime;
                        }
                    }
                    _CssFileName = dt.ToString("yyyyMMddHHmmss") + ".css";
                }
                return _CssFileName;
            }
        }*/


    }
}
