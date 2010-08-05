using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trakker.Core
{
    public class ViewWrapperViewData<TMasterModel, TViewModel>
        : MasterWrapperViewData<TMasterModel>
    {
        public ViewWrapperViewData(TMasterModel masterModel, TViewModel viewModel)
            : base(masterModel)
        {
            View = viewModel;
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        /// <value>The view model.</value>
        public TViewModel View { get; set; }
    }
}
