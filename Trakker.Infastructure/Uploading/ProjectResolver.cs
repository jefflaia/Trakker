using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Data;
using System.IO;

namespace Trakker.Infastructure
{
    public class ProjectAvatarPathResolver : IPathResolver
    {
        private Project _project;
        private string _root;

        public ProjectAvatarPathResolver(string root, Project project)
        {
            _project = project;
            _root = root;
        }

        public string ResolvePath()
        {
            return Path.Combine(_root, "/Project/", _project.KeyName.ToUpper(), "/Avatar/");
        }
    }
}
