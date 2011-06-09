using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Trakker.Routes;
using System;
using System.Web.Mvc;
using Castle.Windsor;
using Trakker.Core.IoC;
using NHibernate;
using Castle.MicroKernel.Registration;



namespace Trakker.Bootstrap
{
    public class ConfigureContainer : IBootstrapperTask
    {
        private IWindsorContainer _container;

        public ConfigureContainer()
        {
            _container = WindsorContainerProvider.Instance();
        }

        public void Execute()
        {
            _container.Register(
                Component.For<ISession>()
                .UsingFactoryMethod(() => NHibernateFactory.OpenSession())
                .LifeStyle.PerWebRequest);
        }
    }
}