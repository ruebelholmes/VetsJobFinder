﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetsJobFinder.Migrations
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

    }
}