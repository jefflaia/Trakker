﻿namespace Trakker.Core {
    using System;
    using System.Web.Mvc;


    public static class ScriptExtensions {
        public static MvcHtmlString Script(this HtmlHelper helper, string releaseFile) {
            return Script(helper, releaseFile, releaseFile);
        }

        public static MvcHtmlString Script(this HtmlHelper helper, string releaseFile, string debugFile) {
            if (String.IsNullOrEmpty(releaseFile)) {
                throw new ArgumentException("cannot be empty or null", "releaseFile");
            }
            if (String.IsNullOrEmpty(debugFile)) {
                throw new ArgumentException("cannot be empty or null", "debugFile");
            }

            string src;
            string file = helper.ViewContext.HttpContext.IsDebuggingEnabled ? debugFile : releaseFile;
            if (IsRelativeToDefaultPath(file)) {
                src = "~/Scripts/" + file;
            }
            else {
                src = file;
            }

            TagBuilder scriptTag = new TagBuilder("script");
            scriptTag.MergeAttribute("type", "text/javascript");
            scriptTag.MergeAttribute("src", UrlHelper.GenerateContentUrl(src, helper.ViewContext.HttpContext));
            return MvcHtmlString.Create(scriptTag.ToString(TagRenderMode.Normal));
        }

        internal static bool IsRelativeToDefaultPath(string file) {
            return !(file.StartsWith("~", StringComparison.Ordinal) ||
                file.StartsWith("../", StringComparison.Ordinal) ||
                file.StartsWith("/", StringComparison.Ordinal) ||
                file.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                file.StartsWith("https://", StringComparison.OrdinalIgnoreCase));
        }
    }
}
