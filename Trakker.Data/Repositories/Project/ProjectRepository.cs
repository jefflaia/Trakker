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

    public class ProjectRepository : IProjectRepository
    {
        protected DataContext _dataContext;
        protected Table<Sql.Project> _projectsTable;
        protected Table<Sql.Component> _componentsTable;




        public ProjectRepository(IDataContextProvider dataContext)
        {
            _dataContext = dataContext.DataContext;
            _projectsTable = _dataContext.GetTable<Sql.Project>();
            _componentsTable = _dataContext.GetTable<Sql.Component>();
        }

        public IQueryable<Project> GetProjects()
        {
            return from p in _projectsTable
                   select new Project()
                   {
                       Id = p.Id,
                       Name = p.Name,
                       Created = p.Created,
                       Due = p.Due,
                       Lead = p.Lead,
                       KeyName = p.KeyName,
                       TicketIndex = p.TicketIndex,
                       Url = p.Url
                   };
        }

        public void Save(Project project)
        {

            Mapper.CreateMap<Project, Sql.Project>();
            Sql.Project p = Mapper.Map<Project, Sql.Project>(project);

            if (project.Id == 0)
            {
                _projectsTable.InsertOnSubmit(p);
            }
            else
            {
                _projectsTable.Attach(p);
                _projectsTable.Context.Refresh(RefreshMode.KeepCurrentValues, p);
            }

            project.Id = p.Id;
        }

        public IQueryable<Component> GetComponents()
        {
            return from c in _componentsTable
                   select new Component()
                   {
                       Id = c.Id,
                       Created = c.Created,
                       Description = c.Description,
                       Name = c.Name,
                       ProjectId = c.ProjectId,
                       TicketId = c.TicketId
                   };
         }

        public void SaveComponent(Component component)
        {
            Mapper.CreateMap<Component, Sql.Component>();
            Sql.Component c = Mapper.Map<Component, Sql.Component>(component);

            if (component.Id == 0)
            {
                _componentsTable.InsertOnSubmit(c);
            }
            else
            {
                _componentsTable.Attach(c);
                _componentsTable.Context.Refresh(RefreshMode.KeepCurrentValues, c);
            }


            component.Id = c.Id;
        }
    }
}
