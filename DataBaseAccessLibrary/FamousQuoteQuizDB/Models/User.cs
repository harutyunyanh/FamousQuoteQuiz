﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataBaseAccessLibrary.FamousQuoteQuizDB.Models
{
    public partial class User
    {
        public User()
        {
            Quiz = new HashSet<Quiz>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationTime { get; set; }

        public virtual ICollection<Quiz> Quiz { get; set; }
    }
}
