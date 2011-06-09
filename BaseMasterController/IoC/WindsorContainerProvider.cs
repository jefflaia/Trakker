namespace Trakker.Core.IoC
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Configuration;
    using Castle.Windsor;
    using Castle.Windsor.Configuration.Interpreters;

    public class WindsorContainerProvider
    {

        private static IWindsorContainer _container;

        private WindsorContainerProvider() { }

        public static IWindsorContainer Instance()
        {
            if (_container == null)
            {
                _container = new WindsorContainer(
                    new XmlInterpreter(GetConfigPath())
                );
            }

            return _container;
        }

        public static string GetConfigPath()
        {
            CastleConfigFileSection fileSection = (CastleConfigFileSection)ConfigurationManager.GetSection("castleConfigFile");
            return fileSection.File.Path;
        }

        public static T Resolve<T>()
        {
            return Instance().Resolve<T>();
        }
    }
}