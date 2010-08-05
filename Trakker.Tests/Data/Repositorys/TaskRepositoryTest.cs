using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using MbUnit.Framework;
using Gallio.Framework;
using Trakker.Data;
using System.Data.SqlClient;

//TODO:: Generate random string hashes that use all characters to test strings, takes a parameter for length, could be a simple base test BaseDBTest
namespace Trakker.Tests._ticketRepositoryTest 
{
    [TestFixture]
    public class _ticketRepositoryTest
    {
        protected ITicketRepository _ticketRepository;


        public _ticketRepositoryTest()
        {
            _ticketRepository = new TicketRepository();
        }

        #region Gets
        [Test]
        public void CanGettickets()
        {
            IList<Ticket> tickets = _ticketRepository.GetTickets().ToList<Ticket>();
            Assert.GreaterThan(tickets.Count, 0);
        }

        [Test]
        public void CanGetPriorities()
        {
            IList<Priority> priority = _ticketRepository.GetPriorities().ToList<Priority>();

            Priority p = new Priority();
            Assert.GreaterThan(priority.Count, 0);
        }

        [Test]
        public void CanGetSeverities()
        {
            IList<Severity> severities = _ticketRepository.GetSeverities().ToList<Severity>();
            Assert.GreaterThan(severities.Count, 0);
        }

        [Test]
        public void CanGetCategory()
        {
            IList<Category> categories = _ticketRepository.GetCategories().ToList<Category>();
            Assert.GreaterThan(categories.Count, 0);
        }

        [Test]
        public void CanGetStatus()
        {
            IList<Status> status = _ticketRepository.GetStatus().ToList<Status>();
            Assert.GreaterThan(status.Count, 0);
        }

        [Test]
        public void CanGetComments()
        {
            IList<Comment> c = _ticketRepository.GetComments().ToList<Comment>();
            Assert.GreaterThan(c.Count, 0);
        }

        #endregion

        #region Saves
        [Test]
        [Rollback]
        public void CanInsertPriorityWithSave()
        {
            const string NAME = "Updated Test Priority";
            const string DESC = "Updated Test Priority";
            const string COLOR = "654321";

            Priority priority = new Priority()
            {
                Name = NAME,
                Description = DESC,
                HexColor = COLOR
            };

            _ticketRepository.Save(priority);

            Assert.GreaterThan(priority.PriorityId, 0);
        }

        [Test]
        [Rollback]
        public void CanUpdatePriorityWithSave()
        {
            const string NAME = "Updated Test Priority";
            const string DESC = "Updated Test Priority";
            const string COLOR = "654321";

            Priority priority = _ticketRepository.GetPriorities()
                .First<Priority>();

            priority.Name = NAME;
            priority.Description = DESC;
            priority.HexColor = COLOR;

            _ticketRepository.Save(priority);

            Priority updatedPriority = _ticketRepository.GetPriorities()
                .Where(x => x.PriorityId == priority.PriorityId)
                .Single();

            Assert.AreEqual(priority.Name, updatedPriority.Name);
            Assert.AreEqual(priority.Description, updatedPriority.Description);
        }

        [Test]
        [Rollback]
        public void CanInsertCategoryWithSave()
        {
            const string NAME = "Updated Test Category";
            const string DESC = "Updated Test Description";

            Category category = new Category()
            {
                Name = NAME,
                Description = DESC
            };

            _ticketRepository.Save(category);

            Assert.GreaterThan(category.CategoryId, 0);

        }

        [Test]
        [Rollback]
        public void CanUpdateCategoryWithSave()
        {
            const string NAME = "Updated Test Category";
            const string DESC = "Updated Test Description";

            Category category = _ticketRepository.GetCategories()
                .First<Category>();

            category.Name = NAME;
            category.Description = DESC;

            _ticketRepository.Save(category);

            Category updatedCategory = _ticketRepository.GetCategories()
                .Where(x => x.CategoryId == category.CategoryId).Single<Category>();

            Assert.AreEqual(category.Name, updatedCategory.Name);
            Assert.AreEqual(category.Description, updatedCategory.Description);
        }


        [Test]
        [Rollback]
        public void CanInsertticketWithSave()
        {
            const string DESC = "Test Description Field";
            const string SUMMARY = "Test Summary Field";


            Ticket ticket = new Ticket()
            {
                Created =  DateTime.Today,
                Description = DESC,
                DueDate =  DateTime.Today,
                PriorityId = 1,
                SeverityId = 1,
                Summary = SUMMARY,
                CategoryId = 1,
                StatusId = 1
            };

            _ticketRepository.Save(ticket);

            Assert.GreaterThan(ticket.TicketId, 0);

        }

        [Test]
        [Rollback]
        public void CanUpdateticketWithSave()
        {
            const string DESC = "Test Description Field";
            const string SUMMARY = "Test Summary Field";

            Ticket ticket = _ticketRepository.GetTickets()
                .First<Ticket>();

            ticket.Description = DESC;
            ticket.Summary = SUMMARY;

            _ticketRepository.Save(ticket);

            Ticket updatedticket = _ticketRepository.GetTickets()
                .Where(x => x.TicketId == ticket.TicketId).Single<Ticket>();

            Assert.AreEqual(ticket.Description, updatedticket.Description);
            Assert.AreEqual(ticket.Summary, updatedticket.Summary);
        }

        [Test]
        [Rollback]
        public void CanInsertStatusWithSave()
        {
            const string NAME = "Test Name Field";
            const string DESC = "Test Description Field";

            Status s = new Status()
            {
                Name = NAME,
                Description = DESC
            };

            _ticketRepository.Save(s);

            Assert.GreaterThan(s.StatusId, 0);

        }

        [Test]
        [Rollback]
        public void CanUpdateStatusWithSave()
        {
            const string NAME = "Updated Test Category";
            const string DESC = "Updated Test Description";

            Status s = _ticketRepository.GetStatus()
                .First<Status>();

            s.Name = NAME;
            s.Description = DESC;

            _ticketRepository.Save(s);

            Status s2 = _ticketRepository.GetStatus()
                .Where(x => x.StatusId == s.StatusId).Single<Status>();

            Assert.AreEqual(s.Name, s2.Name);
            Assert.AreEqual(s.Description, s2.Description);
        }

        [Test]
        [Rollback]
        public void CanInsertSeverityWithSave()
        {
            const string NAME = "Test Name Field";
            const string DESC = "Test Description Field";
            const string COLOR = "654321";

            Severity s = new Severity()
            {
                Name = NAME,
                Description = DESC,
                HexColor = COLOR
            };

            _ticketRepository.Save(s);

            Assert.GreaterThan(s.SeverityId, 0);
        }

        [Test]
        [Rollback]
        public void CanUpdateSeverityWithSave()
        {
            const string NAME = "Test Name Field";
            const string DESC = "Test Description Field";
            const string COLOR = "654321";

            Severity s = _ticketRepository.GetSeverities()
                .First<Severity>();

            s.Name = NAME;
            s.Description = DESC;
            s.HexColor = COLOR;

            _ticketRepository.Save(s);

            Severity s2 = _ticketRepository.GetSeverities()
                .Where(x => x.SeverityId == s.SeverityId).Single<Severity>();

            Assert.AreEqual(s.Name, s2.Name);
            Assert.AreEqual(s.Description, s2.Description);
            Assert.AreEqual(s.HexColor, s2.HexColor);
        }

        [Test]
        [Rollback]
        public void CanInsertCommentWithSave()
        {
            const string BODY = "Test Body field of comment";
   
            Comment c = new Comment()
            {
                Body = BODY,
                Created = DateTime.Today,
                Modified = DateTime.Today.Add(TimeSpan.FromDays(1)),
                TicketId = 10,
                UserId = 1

            };

            _ticketRepository.Save(c);

            Assert.GreaterThan(c.UserId, 0);
        }

        [Test]
        [Rollback]
        public void CanUpdateCommentWithSave()
        {
            const string BODY = "Test Body field of comment Updated";

            Comment c = _ticketRepository.GetComments()
                .First<Comment>();

            c.Body = BODY;

            _ticketRepository.Save(c);

            Comment c2 = _ticketRepository.GetComments()
                .Where(x => x.CommentId == c.CommentId).Single<Comment>();

            Assert.AreEqual(c.Body, c2.Body);

        }

        [Test]
        [Rollback]
        public void CanGenerateProperKeyNameForAticket()
        {
            Ticket ticket = new Ticket()
            {
                Created = DateTime.Today,
                Description = "BLAH",
                DueDate = DateTime.Today,
                PriorityId = 1,
                SeverityId = 1,
                Summary = "DO NOT CHANGE",
                CategoryId = 1,
                StatusId = 1
            };

            _ticketRepository.Save(ticket);

            Assert.AreEqual("do-not-change-2", ticket.KeyName);
        }

        #endregion

        #region Deletes
        [Test]
        [Rollback]
        public void CanDeleteticket()
        {
           const int ID = 22;

           _ticketRepository.DeleteTicket(ID);

           Ticket ticket = _ticketRepository.GetTickets()
               .Where(x => x.TicketId == ID)
               .SingleOrDefault<Ticket>();

           Assert.IsNull(ticket);
        }

        [Test]
        [Rollback]
        public void CanDeletePriority()
        {


            const int ID = 77;

            _ticketRepository.DeletePriority(ID);

            Priority p = _ticketRepository.GetPriorities()
                .Where(x => x.PriorityId == ID)
                .SingleOrDefault<Priority>();

            Assert.IsNull(p);
         
        }

        [Test]
        [Rollback]
        public void CanDeleteStatus()
        {
            const int ID = 16;

            _ticketRepository.DeleteStatus(ID);

            Status s = _ticketRepository.GetStatus()
                .Where(x => x.StatusId == ID)
                .SingleOrDefault<Status>();

            Assert.IsNull(s);
        }

        [Test]
        [Rollback]
        public void CanDeleteSeverity()
        {
            const int ID = 14;

            _ticketRepository.DeleteSeverity(ID);

            Severity s = _ticketRepository.GetSeverities()
                .Where(x => x.SeverityId == ID)
                .SingleOrDefault<Severity>();

            Assert.IsNull(s);
        }

        [Test]
        [Rollback]
        public void CanDeleteCategory()
        {
            const int ID = 26;

            _ticketRepository.DeleteCategory(ID);

            Category c = _ticketRepository.GetCategories()
                .Where(x => x.CategoryId == ID)
                .SingleOrDefault<Category>();

            Assert.IsNull(c);
        }

        [Test]
        [Rollback]
        public void CanDeleteComment()
        {
            const int ID = 1;

            _ticketRepository.DeleteComment(ID);

            Comment c = _ticketRepository.GetComments()
                .Where(x => x.UserId == ID)
                .SingleOrDefault<Comment>();

            Assert.IsNull(c);
        }

        #endregion
    }
}
