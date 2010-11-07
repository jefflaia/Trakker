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
        IQueryable<Priority> GetPriorities();
        void Save(Priority priority);
        void DeletePriority(int id);
        #endregion

        #region Categories
        IQueryable<Category> GetCategories();
        void Save(Category category);
        void DeleteCategory(int id);
        #endregion

        #region Status
        IQueryable<Status> GetStatus();
        void Save(Status status);
        void DeleteStatus(int id);
        #endregion

        #region Comments
        IQueryable<Comment> GetComments();
        void Save(Comment comment);
        void DeleteComment(int id);
        #endregion

        #region Resolution
        IQueryable<Resolution> GetResolutions();
        void Save(Resolution resolution);
        void DeleteResolution(int id);
        #endregion


    }
}
