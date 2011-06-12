namespace Trakker.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Trakker.Data;


    public interface ITicketService
    {
        string GenerateTicketKey(Project project);
        void AddTicketToProject(Ticket ticket, Project project);
    }
}
