

namespace Trakker.Core.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class ByteExtensions
    {
        public static Boolean ToBoolean(this Byte byteValue)
        {
            return BitConverter.ToBoolean(BitConverter.GetBytes(byteValue), 0);
        }
    }
}
