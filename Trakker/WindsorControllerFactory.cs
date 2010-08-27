using System;
using System.Linq;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Castle.Core.Resource;
using System.Web.Mvc;
using System.Web.Routing;
using System.Reflection;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Trakker.Services;
using Trakker.Data;

namespace Trakker
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {

        WindsorContainer container;
        // The constructor:
        // 1. Sets up a new IoC container
        // 2. Registers all components specified in web.config
        // 3. Registers all controller types as components
        public WindsorControllerFactory(string configPath)
        {
            // Instantiate a container, taking configuration from web.config
            container = new WindsorContainer(
                new XmlInterpreter(configPath)
            );

            // Also register all the controller types as transient
            var controllerTypes =
	            from t in Assembly.GetExecutingAssembly().GetTypes()
	            where typeof(IController).IsAssignableFrom(t)
	            select t;

            foreach (Type t in controllerTypes)
            {
                container.AddComponentLifeStyle(t.FullName, t, LifestyleType.Transient);
            }

            container.Register(
                Castle.MicroKernel.Registration.Component.For<IConnectionStringProvider>().ImplementedBy<ConnectionStringProvider>().LifeStyle.Singleton,
                Castle.MicroKernel.Registration.Component.For<IDataContextProvider>().ImplementedBy<DataContextProvider>().LifeStyle.PerWebRequest
            );
        }
	 
        // Constructs the controller instance needed to service each request this part is Updated to be compatible with MVC 2
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return (IController)container.Resolve(controllerType);
        }
      
    }
}