using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using Trakker.Bootstrap;

namespace Trakker
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            //RouteDebug.RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes);
            IList<IBootstrapperTask> tasks = new List<IBootstrapperTask>();

            
            tasks.Add(new RegisterControllerFactory(new WindsorControllerFactory()));
            tasks.Add(new RegisterRoutes());
            tasks.Add(new RegisterAreas()); //must come after routes
            tasks.Add(new RegisterAssets());


            /*
            var bootstrapperTasks =
                from t in Assembly.GetExecutingAssembly().GetTypes()
                where typeof(IBootstrapperTask).IsAssignableFrom(t)
                select Activator.CreateInstance(t);
            */
            foreach (IBootstrapperTask task in tasks)
            {
                task.Execute();
            }
             
        }
    }
}