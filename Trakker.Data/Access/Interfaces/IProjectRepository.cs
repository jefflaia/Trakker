using System;
namespace Trakker.Data.Interfaces.SqlServer
{
    public interface IProjectRepository
    {
        System.Linq.IQueryable<Trakker.Data.Component> GetComponents();
        System.Linq.IQueryable<Trakker.Data.Project> GetProjects();
        void Save(Trakker.Data.Project project);
        void SaveComponent(Trakker.Data.Component component);
    }
}
