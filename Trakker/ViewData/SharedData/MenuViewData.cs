﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trakker.Data;

namespace Trakker.ViewData.SharedData
{
    public class MenuViewData
    {
        public IList<Project> Projects { get; set; }

        public bool HasCurrentProject { get; set; }
        public Project CurrentProject { get; set; }

        public bool IsUserLoggedIn { get; set; }
        public User CurrentUser { get; set; }

        public IList<Ticket> Tickets { get; set; }

        public int NumTicketsAssignedToCurrentUser { get; set; }
    }
}