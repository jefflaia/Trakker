using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Data;
using System.Web.Mvc;
using Trakker.Infastructure.Uploading;
using System.ComponentModel;
using System.IO;
using System.Linq.Expressions;

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
            var builder = new ImageBuilder(new ImageBase(HtmlHelper.ViewContext, new ImageHtmlBuilderFactory(), AssetManager), new AvatarImageProfile());
            builder.Src(Path.Combine(file.Path, file.FileName));
            return builder;

        }

        public ProgressBarBuilder ProgressBar()
        {
            return new ProgressBarBuilder(new ProgressBarBase(HtmlHelper.ViewContext, new ProgressBarHtmlBuilderFactory(), AssetManager));
        }

        public DatePickerBuilder DatePicker()
        {
            return new DatePickerBuilder(new DatePickerBase(HtmlHelper.ViewContext, ClientSideObjectWriterFactory, new DatePickerHtmlBuilderFactory(), AssetManager));
        }
    }

    public class ViewComponentFactory<TModel> : ViewComponentFactory
    {
        public ViewComponentFactory(HtmlHelper<TModel> helper, IClientSideObjectWriterFactory clientSideObjectWriterFactory, IAssetManager assetManager) 
            : base(helper, clientSideObjectWriterFactory, assetManager)
        {
            //set the shadowed helper
            HtmlHelper = helper;
        }

        public new HtmlHelper<TModel> HtmlHelper
        {
            get;
            set;
        }

        public DatePickerBuilder DatePickerFor(Expression<Func<TModel, Nullable<DateTime>>> expression)
        {
            DatePickerBuilder builder = new DatePickerBuilder(new DatePickerBase(HtmlHelper.ViewContext, ClientSideObjectWriterFactory, new DatePickerHtmlBuilderFactory(), AssetManager));
            return builder.Name(GetName(expression))
                          .Value(expression.Compile()(HtmlHelper.ViewData.Model));
        }

        public DatePickerBuilder DatePickerFor(Expression<Func<TModel, DateTime>> expression)
        {
            DatePickerBuilder builder = new DatePickerBuilder(new DatePickerBase(HtmlHelper.ViewContext, ClientSideObjectWriterFactory, new DatePickerHtmlBuilderFactory(), AssetManager));
            return builder.Name(GetName(expression))
                          .Value(expression.Compile()(HtmlHelper.ViewData.Model));
        }


        #region Private Members
        private string GetName(LambdaExpression expression)
        {
            string name = ExpressionHelper.GetExpressionText(expression);
            return HtmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
        }
        #endregion
    }
}
