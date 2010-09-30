using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public interface ITicketRepository
    {
        /********* Ticket *********/
        IQueryable<Ticket> GetTickets();
        void Save(Ticket ticket);
        void DeleteTicket(int id);

        /********* Priority *********/
        IQueryable<Priority> GetPriorities();
        void Save(Priority priority);
        void DeletePriority(int id);

        /********* Category *********/
        IQueryable<Category> GetCategories();
        void Save(Category category);
        void DeleteCategory(int id);

        /********* Status *********/
        IQueryable<Status> GetStatus();
        void Save(Status status);
        void DeleteStatus(int id);

        /********* Comment *********/
        IQueryable<Comment> GetComments();
        void Save(Comment comment);
        void DeleteComment(int id);

    }
}
