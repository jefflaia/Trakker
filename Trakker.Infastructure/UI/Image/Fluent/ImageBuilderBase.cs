using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Infastructure.Uploading;

namespace Trakker.Infastructure.UI
{
    public class ImageBuilderBase<TComponent, TBuilder>
        where TComponent : ImageBase
        where TBuilder : ImageBuilderBase<TComponent, TBuilder>
    {

        public TComponent Component { get; set; }
        public IImageProfile Profile { get; set; }

        public ImageBuilderBase(TComponent component, IImageProfile profile)
        {
            Component = component;
            Profile = profile;
        }

        public TBuilder Small()
        {
            Component.Width = Profile.Icon.Width;
            Component.Height = Profile.Icon.Height;

            return this as TBuilder;
        }

        public TBuilder Medium()
        {
            Component.Width = Profile.Thumbnail.Width;
            Component.Height = Profile.Thumbnail.Height;

            return this as TBuilder;
        }

        public TBuilder Large()
        {
            Component.Width = Profile.Large.Width;
            Component.Height = Profile.Large.Height;

            return this as TBuilder;
        }

        public TBuilder Original()
        {
            Component.Width = 0;
            Component.Height = 0;

            return this as TBuilder;
        }

        public TBuilder Alt(string alt)
        {
            Component.Alt = alt;
            return this as TBuilder;
        }

        public TBuilder Src(string src)
        {
            Component.Src = src;
            return this as TBuilder;
        }
    }
}
