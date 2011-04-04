using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Data;
using Trakker.Infastructure.Streams.Activity.Model;

namespace Trakker.Infastructure.Streams.Activity.Mappers
{
    internal interface IMapper<T>
    {
        ActivityModel Map(T model);
    }
}
