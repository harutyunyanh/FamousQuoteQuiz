using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.DBModels
{
    public class GetQuizModel
    {
        public string Text { get; set; }
        public QuizTypeEnum QuizTypeId { get; set; }
        public int UserId { get; set; }
    }
}
