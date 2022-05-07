using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataBaseAccessLibrary.FamousQuoteQuizDB.Models
{
    public partial class Quiz
    {
        public Quiz()
        {
            History = new HashSet<History>();
        }
        public int Id { get; set; }
        public string Text { get; set; }
        public int QuizTypeId { get; set; }
        public int UserId { get; set; }
        public int RightAnswerId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationTime { get; set; }

        public virtual QuizType QuizType { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<History> History { get; set; }
    }
}
