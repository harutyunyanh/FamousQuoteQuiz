using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.DBModels
{

    public class GetUserDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Login { get; set; }
        public DateTime CreationTime { get; set; }
        public List<GetQuizModel> QuizList { get; set; }
    }
    public class GetUserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Login { get; set; }
        public DateTime CreationTime { get; set; }
    }
    public class AddUserModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

    }
    public class EditUserModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
