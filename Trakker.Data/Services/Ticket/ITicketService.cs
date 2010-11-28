namespace Trakker.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Trakker.Data;


    public interface ITicketService
    {
        /********* Ticket *********/
        Ticket GetTicketWithId(int id);
        IList<Ticket> TicketList(int pageSize, int index);
        Ticket GetTicketWithKeyName(string keyName);
        int CountTicketsWithAssignedTo(int userId);
        IList<Ticket> GetTicketsWithAssignedTo(int userId);
        IList<Ticket> GetNewestTicketsWithProjectId(int projectId, int limit);
        string GenerateTicketKeyName(Project project);
        int TotalTickets();
        void Save(Ticket ticket);

        /********* Comment *********/
        IList<Comment> GetCommentsWithticketId(int id);
        Comment GetCommentWithId(int id);
        void Save(Comment comment);

        /********* Category *********/
        TicketType GetCategoryWithId(int id);
        IList<TicketType> GetAllCategories();

        /********* Priority *********/
        TicketPriority GetPriorityById(int id);
        TicketPriority GetPriorityByName(string name);
        IList<TicketPriority> GetAllPriorities();
        void Save(TicketPriority priority);

        /********* Status *********/
        TicketStatus GetStatusWithId(int id);
        TicketStatus GetStatusByName(string name);
        IList<TicketStatus> GetAllStatus();
        void Save(TicketStatus status);

        #region Resolution
        void Save(TicketResolution resolution);
        IList<TicketResolution> GetAllResolutions();
        TicketResolution GetResolutionById(int resoutionId);
        TicketResolution GetResolutionByName(string name);
        #endregion

    }
}
