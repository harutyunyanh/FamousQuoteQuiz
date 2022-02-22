using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataBaseAccessLibrary.FamousQuoteQuizDB.Models
{
    public partial class History
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int QuizId { get; set; }
        public bool IsRight { get; set; }
        public int AnswerId { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual Client Client { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
