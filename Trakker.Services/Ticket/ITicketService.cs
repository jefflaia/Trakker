using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Data;

namespace Trakker.Services
{
    public interface ITicketService
    {
        /********* Ticket *********/
        Ticket GetTicketWithId(int id);
        IList<Ticket> TicketList(int pageSize, int index);
        Ticket GetTicketWithKeyName(string keyName);
        int CountTicketsWithAssignedTo(int userId);
        IList<Ticket> GetTicketsWithAssignedTo(int userId);
        IList<Ticket> GetNewestTicketsWithProjectId(int projectId, int limit);
        string GenerateTicketKeyName(int projectId);
        int TotalTickets();
        void Save(Ticket ticket);

        /********* Comment *********/
        IList<Comment> GetCommentsWithticketId(int id);
        Comment GetCommentWithId(int id);
        void Save(Comment comment);

        /********* Category *********/
        Category GetCategoryWithId(int id);
        IList<Category> GetAllCategories();

        /********* Priority *********/
        Priority GetPriorityWithId(int id);
        IList<Priority> GetAllPriorities();
        void Save(Priority priority);

        /********* Status *********/
        Status GetStatusWithId(int id);
        IList<Status> GetAllStatus();

        #region Resolution
        void Save(Resolution resolution);
        IList<Resolution> GetAllResolutions();
        Resolution GetResolutionById(int resoutionId);
        #endregion

    }
}
