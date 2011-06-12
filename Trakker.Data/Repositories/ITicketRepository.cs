namespace Trakker.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public interface ITicketRepository
    {
        #region Ticket
        Ticket GetTicketById(int id);
        int TotalTickets();
        int TotalTicketsByAssignedToUser(User user);
        IList<Ticket> GetTicketsByAssignedToUser(User user);
        Ticket GetTicketByKey(string key);

        Paginated<Ticket> GetTicketsByProject(Project project, int page, int pageSize);
        Paginated<Ticket> GetNewestTicketsByProject(Project project, int page, int pageSize);


        void Save(Ticket ticket);

        #endregion

        #region Priority
        TicketPriority GetPriorityByName(string name);
        TicketPriority GetPriorityById(int id);
        IList<TicketPriority> GetPriorities();
        void Save(TicketPriority priority);
        #endregion

        #region Types
        TicketType GetTypeById(int id);
        TicketType GetTypeByName(string name);
        IList<TicketType> GetTypes();
        void Save(TicketType type);
        #endregion

        #region Status

        TicketStatus GetStatusById(int id);
        TicketStatus GetStatusByName(string name);
        IList<TicketStatus> GetStatus();
        void Save(TicketStatus status);

        #endregion

        #region Comments
        Comment GetCommentById(int id);
        IList<Comment> GetComments();
        IList<Comment> GetCommentsByTicket(Ticket ticket);
        IList<Comment> GetCommentsByUser(User user, int page, int pageSize);
        Paginated<Comment> GetCommentsByTicket(Ticket ticket, int page, int pageSize);
        void Save(Comment comment);
        #endregion

        #region Resolution
        TicketResolution GetResolutionById(int id);
        TicketResolution GetResolutionByName(string name);
        IList<TicketResolution> GetResolutions();
        void Save(TicketResolution resolution);
        #endregion
    }
}
