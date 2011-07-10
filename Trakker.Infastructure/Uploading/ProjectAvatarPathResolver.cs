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

        private const string PROJECT_DIR = "Project\\";
        private const string AVATAR_DIR = "Avatar\\";

        private Project _project;
        private string _root;

        public ProjectAvatarPathResolver(string root, Project project)
        {

            if (Directory.Exists(root) == false)
            {
                throw new DirectoryNotFoundException(string.Format("Could not find home directory. Please ensure \"{0}\" exists.", root));
            }

            _project = project;
            _root = EnforceTrailingSlash(root);
        }

        public string ResolvePath()
        {
            return Path.Combine(_root, PROJECT_DIR, _project.KeyName.ToUpper(), AVATAR_DIR);
        }

        public bool PathExists()
        {
            return Directory.Exists(ResolvePath());
        }

        public void CreatePath()
        {
            Directory.CreateDirectory(ResolvePath());
        }

        private string EnforceTrailingSlash(string path)
        {
            char lastChar = path.Last();

            if (lastChar.Equals("\\") == false && lastChar.Equals("/") == false)
            {
                return path + "\\";
            }

            return path;
        }


    }
}
