namespace Trakker.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface ISystemRepository
    {


        Property GetPropertyByKey<T>(string key);
        void Save(Property property);
        
    }
}
