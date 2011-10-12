using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Data;

namespace Trakker.Models.Project
{
    public class ReleaseNotesModel
    {
        public ProjectVersion Version { get; set; }
        public Trakker.Data.Project Project { get; set; }
    }
}
