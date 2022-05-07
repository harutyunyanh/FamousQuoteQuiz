using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataBaseAccessLibrary.FamousQuoteQuizDB.Models
{
    public partial class QuizType
    {
        public QuizType()
        {
            Quiz = new HashSet<Quiz>();
        }
        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Quiz> Quiz { get; set; }
    }
}
