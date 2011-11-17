using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Data;
using System.Web.Mvc;
using Trakker.Infastructure.Uploading;
using System.ComponentModel;
using System.IO;

namespace Trakker.Infastructure.UI
{
    public class ViewComponentFactory
    {

        public ViewComponentFactory(HtmlHelper helper, IClientSideObjectWriterFactory clientSideObjectWriterFactory, IAssetManager assetManager)
        {
            ClientSideObjectWriterFactory = clientSideObjectWriterFactory;
            AssetManager = assetManager;
            HtmlHelper = helper;
        }

        public IAssetManager AssetManager { get; private set; }
        public IClientSideObjectWriterFactory ClientSideObjectWriterFactory { get; private set; }
        public HtmlHelper HtmlHelper { get; set; }

        public ImageBuilder Avatar(Trakker.Data.File file)
        {
            var builder = new ImageBuilder(new ImageBase(HtmlHelper.ViewContext, ClientSideObjectWriterFactory, new ImageHtmlBuilderFactory(), AssetManager), new AvatarImageProfile());
            builder.Src(Path.Combine(file.Path, file.FileName));
            return builder;

        }

        public ProgressBarBuilder ProgressBar()
        {
            return new ProgressBarBuilder(new ProgressBarBase(HtmlHelper.ViewContext, ClientSideObjectWriterFactory, new ProgressBarHtmlBuilderFactory(), AssetManager));
        }

        public DatePickerBuilder DatePicker()
        {
            return new DatePickerBuilder(new DatePickerBase(HtmlHelper.ViewContext, ClientSideObjectWriterFactory, new DatePickerHtmlBuilderFactory(), AssetManager));
        }

    }
}
