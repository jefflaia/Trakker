using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Data.Repositories;

namespace Trakker.Data.Services
{
    public class ProjectService : IProjectService
    {
        private IProjectRepository _projectRepo;
        private ISystemRepository _systemRepo;

        public ProjectService(IProjectRepository projectRepo, ISystemRepository systemRepo)
        {
            _projectRepo = projectRepo;
            _systemRepo = systemRepo;

        }

    }
}
