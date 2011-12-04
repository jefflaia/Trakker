using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Data.Services
{
    public interface IProjectService
    {
        void ChangeProjectAvatar(File file);

        void AddVersion(ProjectVersion version, ProjectVersion afterVersion);
        void MergeVersions(ProjectVersion fromVersion, ProjectVersion toVersion);
        void DeleteVersion(ProjectVersion version);

        void ReleaseVersion(ProjectVersion version);
        void UnreleaseVersion(ProjectVersion version);
    }
}
