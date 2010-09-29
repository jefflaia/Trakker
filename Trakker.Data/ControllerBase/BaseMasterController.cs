using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Trakker.Core
{
    public abstract class BaseMasterController<TMasterViewData> : Controller
    {
        /// <summary>
        /// Views this instance.
        /// </summary>
        /// <returns></returns>
        protected virtual new ActionResult View()
        {
            return View(ViewData.Model);
        }

        /// <summary>
        /// Views the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        protected virtual new ActionResult View(object model)
        {
            var masterModel = GetMasterViewData();
            object wrapper = CreateModel(model, masterModel);

            return base.View(wrapper);
        }

        /// <summary>
        /// Gets the master view model.
        /// override this in your master controller.
        /// </summary>
        /// <returns></returns>
        protected virtual TMasterViewData GetMasterViewData()
        {
            return default(TMasterViewData);
        }

        /// <summary>
        /// Creates the model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="masterModel">The master model.</param>
        /// <returns></returns>
        private static object CreateModel(object model, TMasterViewData masterModel)
        {
            var modelType = typeof(object);

            if (model != null)
                modelType = model.GetType();

            var types = new[] { typeof(TMasterViewData), modelType };
            Type generic = typeof(ViewWrapperViewData<,>).MakeGenericType(types);

            return Activator.CreateInstance(generic, masterModel, model);
        }
    }

}
