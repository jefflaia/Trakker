using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO.Compression;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using System.Collections;

namespace Trakker.Filters
{
    public class CompressFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpRequestBase request = filterContext.HttpContext.Request;

            string[] supported = new string[] { "gzip", "deflate" };

            IEnumerable<string> preferredOrder = new AcceptList(request.Headers["Accept-Encoding"], supported);

            string preferred = preferredOrder.FirstOrDefault();

            HttpResponseBase response = filterContext.HttpContext.Response;

            switch (preferred)
            {
                case "gzip":
                    response.AppendHeader("Content-Encoding", "gzip");
                    response.Filter = new GZipStream(response.Filter, CompressionMode.Compress);
                    break;

                case "deflate":
                    response.AppendHeader("Content-Encoding", "deflate");
                    response.Filter = new DeflateStream(response.Filter, CompressionMode.Compress);
                    break;

                case "identity":
                default:
                    break;
            }
        }
    }

    public class AcceptList : IEnumerable<string>
    {
        Regex parser = new Regex(@"(?<name>[^;,\r\n]+)(?:;q=(?<value>[\d.]+))?", RegexOptions.Compiled);

        IEnumerable<string> encodings;

        public AcceptList(string acceptHeaderValue, IEnumerable<string> supportedEncodings)
        {
            List<KeyValuePair<string, float>> accepts = new List<KeyValuePair<string, float>>();

            if (!string.IsNullOrEmpty(acceptHeaderValue))
            {
                MatchCollection matches = parser.Matches(acceptHeaderValue);

                var values = from Match v in matches
                             where v.Success
                             select new
                             {
                                 Name = v.Groups["name"].Value,
                                 Value = v.Groups["value"].Value
                             };

                foreach (var value in values)
                {
                    if (value.Name == "*")
                    {
                        foreach (string encoding in supportedEncodings)
                        {
                            if (!accepts.Where(a => a.Key.ToUpperInvariant() == encoding.ToUpperInvariant()).Any())
                            {
                                accepts.Add(new KeyValuePair<string, float>(encoding, 1.0f));
                            }
                        }

                        continue;
                    }

                    float desired = 1.0f;
                    if (!string.IsNullOrEmpty(value.Value))
                    {
                        float.TryParse(value.Value, out desired);
                    }

                    if (desired == 0.0f)
                    {
                        continue;
                    }

                    accepts.Add(new KeyValuePair<string, float>(value.Name, desired));
                }
            }

            this.encodings = from a in accepts
                             where supportedEncodings.Where(se => se.ToUpperInvariant() == a.Key.ToUpperInvariant()).Any() || a.Key.ToUpperInvariant() == "IDENTITY"
                             orderby a.Value descending
                             select a.Key;
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            return this.encodings.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this.encodings).GetEnumerator();
        }
    }
}