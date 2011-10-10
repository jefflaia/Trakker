using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trakker.Data;


namespace Trakker.Models.Ticket
{
    public class CommentCreateEditModel : MasterModel
    {
        public Comment Comment { get; set; }
    }
}
