using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Data.Repositories;
using Trakker.Data.Utilities;

namespace Trakker.Data.Services
{
    public class ProjectService : IProjectService
    {
        private IProjectRepository _projectRepo;
        private ISystemRepository _systemRepo;
        private IUnitOfWork _uow;

        public ProjectService(IUnitOfWork unitOfWork, IProjectRepository projectRepo, ISystemRepository systemRepo)
        {
            _projectRepo = projectRepo;
            _systemRepo = systemRepo;
            _uow = unitOfWork;

        }


        public void ChangeProjectAvatar(File file)
        {
            file.Usage = FileUsage.ProjectAvatar;
            _systemRepo.Save(file);
        }

        #region Version
        public void AddVersion(ProjectVersion version, ProjectVersion afterVersion)
        {
            if (afterVersion != null)
            {
                version.SortOrder = afterVersion.SortOrder;
            }

            _projectRepo.IncrememtOrderingAfterVersion(version);
            _projectRepo.Save(version);
        }
        
        public void MergeVersions(ProjectVersion fromVersion, ProjectVersion toVersion)
        {
            throw new NotImplementedException();
        }

        public void DeleteVersion(ProjectVersion version)
        {
            _projectRepo.RemoveVersionFromTickets(version);
            _projectRepo.Delete(version);
        }

        public void ReleaseVersion(ProjectVersion version)
        {
            version.IsReleased = true;
            _projectRepo.Save(version);
        }

        public void UnreleaseVersion(ProjectVersion version)
        {
            version.IsReleased = false;
            _projectRepo.Save(version);
        }
        #endregion
    }
}
