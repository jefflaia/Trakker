using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Infastructure
{
    using System.Diagnostics;
    using System.Globalization;

    /// <summary>
    /// Helper class to get currrent and invariant culture.
    /// </summary>
    public static class Culture
    {
        /// <summary>
        /// Gets the System.Globalization.CultureInfo that represents the current culture used by the Resource Manager to look up culture-specific resources at run time.
        /// </summary>
        /// <value>The current.</value>
        public static CultureInfo Current
        {
            [DebuggerStepThrough]
            get
            {
                return CultureInfo.CurrentCulture;
            }
        }

        /// <summary>
        /// Gets the System.Globalization.CultureInfo that represents the current UI culture
        /// </summary>
        /// <value>The current.</value>
        public static CultureInfo CurrentUI
        {
            [DebuggerStepThrough]
            get
            {
                return CultureInfo.CurrentUICulture;
            }
        }

        /// <summary>
        /// Gets the System.Globalization.CultureInfo that is culture-independent (invariant).
        /// </summary>
        /// <value>The invariant.</value>
        public static CultureInfo Invariant
        {
            [DebuggerStepThrough]
            get
            {
                return CultureInfo.InvariantCulture;
            }
        }
    }
}
