﻿namespace Trakker.Core {
    using System;
    using System.Web.Mvc;

    public static class CssExtensions {
        public static MvcHtmlString Css(this HtmlHelper helper, string file) {
            return Css(helper, file, null);
        }

        public static MvcHtmlString Css(this HtmlHelper helper, string file, string mediaType) {
            if (String.IsNullOrEmpty(file)) {
                throw new ArgumentException("cannot be empty or null", "file");
            }

            string src;
            if (ScriptExtensions.IsRelativeToDefaultPath(file)) {
                src = "~/Content/" + file;
            }
            else {
                src = file;
            }

            TagBuilder linkTag = new TagBuilder("link");
            linkTag.MergeAttribute("type", "text/css");
            linkTag.MergeAttribute("rel", "stylesheet");
            if (mediaType != null) {
                linkTag.MergeAttribute("media", mediaType);
            }
            linkTag.MergeAttribute("href", UrlHelper.GenerateContentUrl(src, helper.ViewContext.HttpContext));
            return MvcHtmlString.Create(linkTag.ToString(TagRenderMode.SelfClosing));
        }
    }
}
