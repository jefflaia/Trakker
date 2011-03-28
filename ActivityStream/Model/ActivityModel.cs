using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActivityStream.Model
{
    public class ActivityModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public DateTime Created { get; set; }
        public bool IsChange { get; set; }
        public String ChangedField { get; set; }
        public String ChangedValue { get; set; }

        public Boolean HasComment()
        {
            return Comment.Length != 0;
        }
    }
}
