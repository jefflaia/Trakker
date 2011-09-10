﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Infastructure.UI
{
    /// <summary>
    /// Provides an attribute to change the enum value for client side.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1813:AvoidUnsealedAttributes", Justification = "Sealed in public class is a design smell, we can ignore the little performace benifit of sealed.")]
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ClientSideEnumValueAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientSideEnumValueAttribute"/> class with the specified value for the client side.
        /// </summary>
        /// <param name="value">The value.</param>
        public ClientSideEnumValueAttribute(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets or sets the value for client side.
        /// </summary>
        /// <value>The value.</value>
        public string Value
        {
            get;
            private set;
        }
    }
}
