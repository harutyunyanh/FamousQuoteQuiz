using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.DBModels
{
    public class LoginModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class SignModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

    }
    public class LoginResponse
    {
        public string Token { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }


    }
}
