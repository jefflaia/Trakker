namespace Trakker.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Trakker.Data.Repositories;
    using System.Globalization;

    public class SystemService : ISystemService
    {
        protected ISystemRepository _systemRepository;

        public SystemService(ISystemRepository systemRepository)
        {
            _systemRepository = systemRepository;
        }

        public Property<T> GetPropertyByName<T>(string name)
        {
            return _systemRepository.GetPropertyByName<T>(name);
        }

        public void Save<T>(Property<T> property)
        {
            _systemRepository.Save<T>(property);
        }
    }
}