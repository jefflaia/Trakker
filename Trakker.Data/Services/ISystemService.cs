using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Data.Services
{
    public interface ISystemService
    {
        Property<T> GetPropertyByName<T>(string name);
        void Save<T>(Property<T> property);
    }
}
