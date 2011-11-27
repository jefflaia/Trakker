using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Moq;
using System.IO;
using System.Diagnostics;
using System.Web.Routing;
using System.Web;
using System.Collections;
using System.Collections.Specialized;
using System.Web.UI;

namespace Trakker.Tests
{
    public static class TestHelper
    {
        public const string AppPathModifier = "/$(SESSION)";
        public const string ApplicationPath = "/app/";

        private static Mock<HttpContextBase> httpContext;
        private static object sync = new object();

        [DebuggerStepThrough]
        public static HtmlHelper CreateHtmlHelper()
        {
            Mock<IViewDataContainer> viewDataContainer = new Mock<IViewDataContainer>();

            viewDataContainer.SetupGet(container => container.ViewData).Returns(new ViewDataDictionary());

            ViewContext viewContext = TestHelper.CreateViewContext();

            HtmlHelper helper = new HtmlHelper(viewContext, viewDataContainer.Object);

            return helper;
        }

        public static ViewContext CreateViewContext()
        {
            return new ViewContext(CreateControllerContext(), new Mock<IView>().Object, new ViewDataDictionary(), new TempDataDictionary(), TextWriter.Null);
        }

        public static ControllerContext CreateControllerContext()
        {
            return new ControllerContext(CreateRequestContext(), new ControllerTestDouble(new Dictionary<string,
                ValueProviderResult>(), new Mock<IViewDataContainer>().Object.ViewData));
        }

        [DebuggerStepThrough]
        public static RequestContext CreateRequestContext()
        {
            return new RequestContext(CreateMockedHttpContext().Object, new RouteData
            {
                Values =
                    {
                        {"controller", "home"},
                        {"action", "index"}
                    }
            });
        }

        [DebuggerStepThrough]
        public static Mock<HttpContextBase> CreateMockedHttpContext()
        {
            return CreateMockedHttpContext(false);
        }

        [DebuggerStepThrough]
        public static Mock<HttpContextBase> CreateMockedHttpContext(bool createNew)
        {
            if (createNew)
            {
                return MockedHttpContext();
            }

            if (httpContext == null)
            {
                lock (sync)
                {
                    if (httpContext == null)
                    {
                        httpContext = MockedHttpContext();
                    }
                }
            }

            httpContext.Setup(context => context.Items).Returns(new Hashtable());

            return httpContext;
        }

        private static Mock<HttpContextBase> MockedHttpContext()
        {
            Mock<HttpContextBase> result = new Mock<HttpContextBase>();
            result.Setup(context => context.Server).Returns(new Mock<HttpServerUtilityBase>().Object);
            result.Setup(context => context.Request.AppRelativeCurrentExecutionFilePath).Returns("~/");
            result.Setup(context => context.Request.ApplicationPath).Returns(ApplicationPath);
            result.Setup(context => context.Request.Url).Returns(new Uri("http://localhost"));
            result.Setup(context => context.Request.PathInfo).Returns(string.Empty);
            result.Setup(context => context.Request.Browser.CreateHtmlTextWriter(It.IsAny<TextWriter>())).Returns((TextWriter tw) => new HtmlTextWriter(tw));
            result.Setup(context => context.Request.Browser.EcmaScriptVersion).Returns(new Version("5.0"));
            result.Setup(context => context.Request.Browser.SupportsCss).Returns(true);
            result.Setup(context => context.Request.Browser.MajorVersion).Returns(7);
            result.Setup(context => context.Request.Browser.IsBrowser("IE")).Returns(false);
            result.Setup(context => context.Request.QueryString).Returns(new NameValueCollection());
            result.Setup(context => context.Request.Headers).Returns(new NameValueCollection { { "Accept-Encoding", "gzip" } });
            result.Setup(context => context.Items).Returns(new Hashtable());
            result.Setup(context => context.Response.Output).Returns(new Mock<TextWriter>().Object);

            result.Setup(context => context.Response.Filter).Returns(new Mock<Stream>().Object);
            // ReSharper disable AccessToStaticMemberViaDerivedType
            result.Setup(context => context.Response.ContentEncoding).Returns(UTF8Encoding.Default);
            // ReSharper restore AccessToStaticMemberViaDerivedType
            result.Setup(context => context.Response.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(r => AppPathModifier + r);
            return result;
        }

        public class ControllerTestDouble : Controller
        {
            public ControllerTestDouble(IDictionary<string, ValueProviderResult> valueProviderData, ViewDataDictionary viewData)
            {
#if MVC1
            ValueProvider = valueProviderData;
#endif
#if MVC2
            ValueProvider = new ValueProvider(valueProviderData);
#endif
                ViewData = viewData;
                ControllerContext = new ControllerContext(TestHelper.CreateRequestContext(), this);
            }
        }
    }
}
