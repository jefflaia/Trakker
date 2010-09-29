using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Core
{
    public class MasterWrapperViewData<TMasterModel>
    {
        public MasterWrapperViewData(TMasterModel masterModel)
        {
            Master = masterModel;
        }

        /// <summary>
        /// Gets or sets the master model.
        /// </summary>
        /// <value>The master model.</value>
        public TMasterModel Master { get; set; }
    }
}
