namespace Trakker.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public interface ITicketRepository
    {
        #region Ticket
        IQueryable<Ticket> GetTickets();
        void Save(Ticket ticket);
        void DeleteTicket(int id);
        #endregion

        #region Priority
        IQueryable<TicketPriority> GetPriorities();
        void Save(TicketPriority priority);
        void DeletePriority(int id);
        #endregion

        #region Categories
        IQueryable<TicketType> GetCategories();
        void Save(TicketType category);
        void DeleteCategory(int id);
        #endregion

        #region Status
        IQueryable<TicketStatus> GetStatus();
        void Save(TicketStatus status);
        void DeleteStatus(int id);
        #endregion

        #region Comments
        IQueryable<Comment> GetComments();
        void Save(Comment comment);
        void DeleteComment(int id);
        #endregion

        #region Resolution
        IQueryable<TicketResolution> GetResolutions();
        void Save(TicketResolution resolution);
        void DeleteResolution(int id);
        #endregion


    }
}
