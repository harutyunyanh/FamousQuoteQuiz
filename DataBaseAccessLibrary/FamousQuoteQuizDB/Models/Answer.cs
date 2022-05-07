using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataBaseAccessLibrary.FamousQuoteQuizDB.Models
{
    public partial class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int QuizId { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
