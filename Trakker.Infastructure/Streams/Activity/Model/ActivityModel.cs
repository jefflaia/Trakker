using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Data;

namespace Trakker.Infastructure.Streams.Activity.Model
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

        public User User { get; set; }

        public Boolean HasComment()
        {
            return Comment.Length != 0;
        }
    }
}
