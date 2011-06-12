namespace Trakker.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AutoMapper;
    using System.Data.Linq;
    using Trakker.Data;

    using Sql = Access;
    using NHibernate;

    public class ProjectRepository : Repository, IProjectRepository
    {

        public ProjectRepository(ISession session) : base(session)
        {

        }

        #region Project
        public IList<Project> GetProjects()
        {
            return GetAll<Project>();
        }

        public Project GetProjectByName(string name)
        {
            return GetSingleBy<Project>(m => m.Name, name);
        }

        public Project GetProjectByKey(string key)
        {
            return GetSingleBy<Project>(m => m.KeyName, key);
        }

        public Project GetProjectById(int id)
        {
            return GetById<Project>(id);
        }


        public void Save(Project project)
        {
            //exsiting project
            //override created / keyname with old values. These values are not allowed to be changed.
            if (project.Id > 0)
            {
                Project oldProject = GetById<Project>(project.Id);
                project.KeyName = oldProject.KeyName.ToUpper();
                project.Created = oldProject.Created;
            }
            //new project
            else
            {
                project.Created = DateTime.Now;
                project.KeyName = project.KeyName.ToUpper();
            }

            base.Save(project);
        }
        #endregion

        #region Component
        public IList<Component> GetComponents()
        {
            return GetAll<Component>();    
        }

        public void SaveComponent(Component component)
        {
            base.Save(component);
        }
        #endregion
    }
}
