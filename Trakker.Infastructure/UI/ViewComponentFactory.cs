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
using System.Web.UI;

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
        public HtmlTextWriter Writer { get; set; }

        public ImageBuilder Avatar(Trakker.Data.File file)
        {
            var component = new ImageBase(AssetManager);
            var builder = new ImageBuilder(component, new AvatarImageProfile(), new ImageHtmlBuilder(component), Writer);
            builder.Src(Path.Combine(file.Path, file.FileName));
            return builder;

        }

        public ProgressBarBuilder ProgressBar(int current, int max)
        {
            var component = new ProgressBar(AssetManager)
            {
                Current = current,
                Max = max
            };

            return new ProgressBarBuilder(component, new ProgressBarHtmlBuilder(component), Writer);
        }

        public DatePickerBuilder DatePicker(string name, DateTime? dateTime)
        {
            var component = new DatePickerBase(AssetManager);

            return new DatePickerBuilder(component, new DatePickerHtmlBuilder(component), ClientSideObjectWriterFactory, Writer);
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
            return DatePicker(GetName(expression), expression.Compile()(HtmlHelper.ViewData.Model));
        }

        public DatePickerBuilder DatePickerFor(Expression<Func<TModel, DateTime>> expression)
        {
            return DatePicker(GetName(expression), expression.Compile()(HtmlHelper.ViewData.Model));
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
