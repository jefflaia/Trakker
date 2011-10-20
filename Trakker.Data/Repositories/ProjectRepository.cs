namespace Trakker.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AutoMapper;
    using System.Data.Linq;
    using Trakker.Data;
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

        #region ColorPalette
        public ColorPalette GetColorPaletteById(int id)
        {
            return GetById<ColorPalette>(id);
        }

        public ColorPalette GetColorPaletteByName(string name)
        {
            return GetSingleBy<ColorPalette>(m => m.Name, name);
        }

        public IList<ColorPalette> GetColorPalettes()
        {
            return GetAll<ColorPalette>();
        }

        public void Save(ColorPalette palette)
        {
            base.Save(palette);
        }
        #endregion

        #region Component
        public IList<Component> GetComponents()
        {
            return GetAll<Component>();    
        }

        public void Save(Component component)
        {
            base.Save(component);
        }
        #endregion

        #region Version
        public void Save(ProjectVersion version)
        {
            if (version.Id == 0)
            {
                Session.CreateQuery("update ProjectVersion set SortOrder = SortOrder + 1 where SortOrder >= ? and ProjectId = ?")
                    .SetInt32(0, version.SortOrder)
                    .SetInt32(1, version.ProjectId)
                    .ExecuteUpdate();
            }
            
            base.Save(version);

        }

        public ProjectVersion GetVersionById(int id)
        {
            return GetById<ProjectVersion>(id);
        }

        public ProjectVersion GetVersionByName(string name)
        {
            return Session.CreateQuery("from ProjectVersion pv where pv.Name = ?")
                .SetString(0, name)
                .UniqueResult<ProjectVersion>();
        }

        public IList<ProjectVersion> GetVersionsByProject(Project project)
        {
            return Session.CreateQuery("from ProjectVersion pv where pv.ProjectId = ? order by pv.SortOrder desc")
                .SetInt32(0, project.Id)
                .List<ProjectVersion>();
        }

        public int NumberOfTicketsToBeFixed(ProjectVersion version)
        {
            return Convert.ToInt32(Session.CreateQuery(@"
                    select count(v.Id) 
                    from ProjectVersion v 
                    left join v.FixedTickets ft
                    where v.Id = ?")
                .SetInt32(0, version.Id)
                .UniqueResult<Int64>());
        }

        public int NumberOfTicketsFound(ProjectVersion version)
        {
            return Convert.ToInt32(Session.CreateQuery(@"
                    select count(v.Id) 
                    from ProjectVersion v 
                    left join v.FoundTickets ft
                    where v.Id = ?")
                .SetInt32(0, version.Id)
                .UniqueResult<Int64>());
        }
        #endregion

    }
}
