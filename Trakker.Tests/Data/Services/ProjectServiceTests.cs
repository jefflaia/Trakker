using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Trakker.Data.Repositories;
using Moq;
using Trakker.Data.Services;
using Trakker.Data.Utilities;
using Trakker.Data;

namespace Trakker.Tests.Data.Services
{
    [TestFixture]
    public class ProjectServiceTests
    {
        IProjectService _projectService;

        Mock<IProjectRepository> _mockProjectRepo;
        Mock<ISystemRepository> _mockSystemRepo;
        Mock<IUnitOfWork> _mockUnitOfWork;

        public ProjectServiceTests()
        {
            _mockProjectRepo = new Mock<IProjectRepository>();
            _mockSystemRepo = new Mock<ISystemRepository>();

            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _projectService = new ProjectService(_mockUnitOfWork.Object, _mockProjectRepo.Object, _mockSystemRepo.Object);

        }

        #region AddVersion
        [Test]
        public void Ensure_AddVersion_Adds_The_New_Version_After_The_Selected_Version()
        {
            ProjectVersion version = new ProjectVersion { SortOrder = 1 };
            ProjectVersion afterVersion = new ProjectVersion { SortOrder = 2};

            _projectService.AddVersion(version, afterVersion);

            Assert.AreEqual(afterVersion.SortOrder, version.SortOrder);
        }

        [Test]
        public void Ensure_AddVersion_Calls_Methods_In_Correct_Order()
        {
            ProjectVersion version = new ProjectVersion { SortOrder = 1 };
            ProjectVersion afterVersion = new ProjectVersion { SortOrder = 2 };

            _projectService.AddVersion(version, afterVersion);

            _mockProjectRepo.Verify(x => x.IncrememtOrderingAfterVersion(version));
            _mockProjectRepo.Verify(x => x.Save(version));
        }

        [Test]
        public void Ensure_AddVersion_Does_Not_Throw_Exception_For_Null_AfterVersion()
        {
            ProjectVersion version = new ProjectVersion { SortOrder = 1 };
            ProjectVersion afterVersion = null;

            _projectService.AddVersion(version, afterVersion);
        }
        #endregion

        #region ReleaseVersion
        [Test]
        public void Ensure_ReleaseVersion_Sets_Properties_Correctly()
        {
            ProjectVersion version = new ProjectVersion { };

            _projectService.ReleaseVersion(version);

            Assert.AreEqual(true, version.IsReleased);
        }

        [Test]
        public void Ensure_ReleaseVersion_Calls_Correct_Methods()
        {
            ProjectVersion version = new ProjectVersion { };

            _projectService.ReleaseVersion(version);

            _mockProjectRepo.Verify(x => x.Save(version));
        }
        #endregion

        #region UnreleaseVersion
        [Test]
        public void Ensure_UnreleaseVersion_Sets_Properties_Correctly()
        {
            ProjectVersion version = new ProjectVersion { IsReleased = true };

            _projectService.UnreleaseVersion(version);

            Assert.AreEqual(false, version.IsReleased);
        }

        [Test]
        public void Ensure_UnreleaseVersion_Calls_Correct_Methods()
        {
            ProjectVersion version = new ProjectVersion { };

            _projectService.ReleaseVersion(version);

            _mockProjectRepo.Verify(x => x.Save(version));
        }
        #endregion

        #region DeleteVersion
        [Test]
        public void Ensure_DeleteVersion_Calls_Correct_Methods()
        {
            ProjectVersion version = new ProjectVersion { };
            _projectService.DeleteVersion(version);

            _mockProjectRepo.Verify(x => x.RemoveVersionFromTickets(version));
            _mockProjectRepo.Verify(x => x.Delete(version));
        }
        #endregion

    }
}
