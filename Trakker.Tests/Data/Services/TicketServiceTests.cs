using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Trakker.Data.Repositories;
using Moq;
using Trakker.Data.Services;
using Trakker.Data.Utilities;
using Trakker.Data;

namespace Trakker.Tests.Data.Services
{
    [TestFixture]
    public class TicketServiceTests
    {
        ITicketService _ticketService;

        Mock<ITicketRepository> _mockTicketRepo;
        Mock<IProjectRepository> _mockProjectRepo;
        Mock<IUnitOfWork> _mockUnitOfWork;

        public TicketServiceTests()
        {
            _mockTicketRepo = new Mock<ITicketRepository>();
            _mockProjectRepo = new Mock<IProjectRepository>();

            _mockProjectRepo.Setup(p => p.Save(It.Is<Project>(isp => isp != null)));

            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _ticketService = new TicketService(_mockUnitOfWork.Object, _mockTicketRepo.Object, _mockProjectRepo.Object);

        }


        [Test]
        public void Ensure_GenerateTicketKey_Generates_Key_Correctly()
        {
            Project project = new Project
            {
                ColorPaletteId = 1,
                Created = DateTime.Now,
                Due = DateTime.Now,
                Id = 1,
                KeyName = "TEST",
                Lead = 1,
                Name = "The Test Project",
                TicketIndex = 10,
                Url = "www.test.com"                
            };

            for (int i = 0; i < 10000; i += 100)
            {
                project.TicketIndex = i;
                string key = _ticketService.GenerateTicketKey(project);
                Assert.AreEqual("TEST-" + i, key);
            }            
        }

        [Test]
        public void Ensure_AddTicketToProject_Increments_Project_TicketIndex()
        {
            Project project = new Project
            {
                TicketIndex = 1
            };

            Ticket ticket = new Ticket();

            _ticketService.AddTicketToProject(ticket, project);
            Assert.AreEqual(2, project.TicketIndex);
        }

        [Test]
        public void Ensure_AddTicketToProject_Sets_ProjectId_For_Ticket()
        {
            Project project = new Project
            {
                Id = 99
            };

            Ticket ticket = new Ticket();

            _ticketService.AddTicketToProject(ticket, project);
            Assert.AreEqual(99, ticket.ProjectId);
        }

        [Test]
        public void Ensure_AddTicketToProject_Saves_Ticket()
        {
            Project project = new Project();
            Ticket ticket = new Ticket();

            _ticketService.AddTicketToProject(ticket, project);
            _mockTicketRepo.Verify(tr => tr.Save(ticket));
        }

        [Test]
        public void Ensure_AddTicketToProject_Saves_Project()
        {
            Project project = new Project();
            Ticket ticket = new Ticket();

            _ticketService.AddTicketToProject(ticket, project);
            _mockProjectRepo.Verify(pr => pr.Save(project));
        }

        public void Ensure_AddTicketToProject_Uses_UnitOfWork()
        {
            Project project = new Project();
            Ticket ticket = new Ticket();

            _ticketService.AddTicketToProject(ticket, project);

            //test both beging and commit
            //cannot test method ordering
            _mockUnitOfWork.Verify(uow => uow.Begin());            
            _mockUnitOfWork.Verify(uow => uow.Commit());
        }

    }
}
