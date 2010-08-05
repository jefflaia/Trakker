using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Data.Linq;
using Trakker.Data.Interfaces.SqlServer;

namespace Trakker.Data
{
    using Sql = Access.SqlServer;

    public class ProjectRepository : IProjectRepository
    {
        protected Sql.TrakkerDBDataContext _db = new Sql.TrakkerDBDataContext();

        public IQueryable<Project> GetProjects()
        {
            return from p in _db.Projects
                   select new Project()
                   {
                       ProjectId = p.ProjectId,
                       Name = p.Name,
                       Created = p.Created,
                       Due = p.Due,
                       Lead = p.Lead,
                       KeyName = p.KeyName
                   };
        }

        public void Save(Project project)
        {
            using (Sql.TrakkerDBDataContext ctx = new Sql.TrakkerDBDataContext())
            {

                Mapper.CreateMap<Project, Sql.Project>();
                Sql.Project p = Mapper.Map<Project, Sql.Project>(project);

                if (project.ProjectId == 0)
                {
                    ctx.Projects.InsertOnSubmit(p);
                }
                else
                {
                    ctx.Projects.Attach(p);
                    ctx.Projects.Context.Refresh(RefreshMode.KeepCurrentValues, p);
                }

                ctx.SubmitChanges();

                project.ProjectId = p.ProjectId;
            };
        }

        public IQueryable<Component> GetComponents()
        {
            return from c in _db.Components
                   select new Component()
                   {
                       ComponentId = c.ComponentId,
                       Created = c.Created,
                       Description = c.Description,
                       Name = c.Name,
                       ProjectId = c.ProjectId,
                       TicketId = c.TicketId
                   };
         }

        public void SaveComponent(Component component)
        {
            using (Sql.TrakkerDBDataContext ctx = new Sql.TrakkerDBDataContext())
            {
                Mapper.CreateMap<Component, Sql.Component>();
                Sql.Component c = Mapper.Map<Component, Sql.Component>(component);

                if (component.ComponentId == 0)
                {
                    ctx.Components.InsertOnSubmit(c);
                }
                else
                {
                    ctx.Components.Attach(c);
                    ctx.Components.Context.Refresh(RefreshMode.KeepCurrentValues, c);
                }

                ctx.SubmitChanges();

                component.ComponentId = c.ComponentId;
            };
        }
    }
}
