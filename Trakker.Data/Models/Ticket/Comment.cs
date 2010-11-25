using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public class Comment
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public int TicketId { get; set; }
        public int UserId { get; set; }

    }
}
