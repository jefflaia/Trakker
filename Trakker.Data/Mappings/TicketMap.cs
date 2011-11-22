using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Trakker.Data.Mappings
{
    public class TicketMap : ClassMap<Ticket>
    {
        public TicketMap()
        {
            #region Properties
            Id(p => p.Id).GeneratedBy.Identity();
            Map(p => p.TypeId);
            Map(p => p.Summary);
            Map(p => p.PriorityId);
            Map(p => p.Description);
            Map(p => p.Created);
            Map(p => p.DueDate);
            Map(p => p.StatusId);
            Map(p => p.ResolutionId);
            Map(p => p.IsClosed);
            Map(p => p.AssignedToUserId);
            Map(p => p.CreatedByUserId);
            Map(p => p.AssignedByUserId);
            Map(p => p.ProjectId);
            Map(p => p.KeyName);
            #endregion

            #region Lookups
            References<TicketType>(p => p.Type)
                .Column("TypeId")
                .Not.Insert()
                .Not.Update();

            References<TicketPriority>(p => p.Priority)
                .Column("PriorityId")
                .Not.Insert()
                .Not.Update();

            References<TicketStatus>(p => p.Status)
                .Column("StatusId")
                .Not.Insert()
                .Not.Update();

            References<TicketResolution>(p => p.Resolution)
                .Column("ResolutionId")
                .Not.Insert()
                .Not.Update();
            
            References<User>(p => p.AssignedBy)
                .Column("AssignedByUserId")
                .Not.Insert()
                .Not.Update();

            References<User>(p => p.AssignedTo)
                .Column("AssignedToUserId")
                .Not.Insert()
                .Not.Update();

            References<User>(p => p.CreatedBy)
                .Column("CreatedByUserId")
                .Not.Insert()
                .Not.Update();
            #endregion

            #region ManyToMany
            HasManyToMany<ProjectVersion>(m => m.FixedOnVersions)
                .Table("TicketFixedOnVersion")
                .ParentKeyColumn("TicketId")
                .ChildKeyColumn("VersionId")
                .Cascade.SaveUpdate();

            HasManyToMany<Ticket>(m => m.FoundOnVersions)
                .Table("TicketFoundOnVersion")
                .ParentKeyColumn("TicketId")
                .ChildKeyColumn("VersionId")
                .Cascade.SaveUpdate();
            #endregion

        }
    }
}
