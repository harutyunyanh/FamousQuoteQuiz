using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.DBModels
{
    public class GetUserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Login { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
