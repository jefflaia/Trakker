using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trakker.Data;
using Trakker.Data.Services;

namespace Trakker.Models
{
    public class CommentModel : MasterModel
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public int ticketId { get; set; }

    }
}
