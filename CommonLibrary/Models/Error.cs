using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Models
{
    public class Error
    {
        public string Code { get; set; }
        public string Message { get; set; } // TODO Add multilingual errors
        public Error(string code, string message) { Code = code; Message = message; }
    }
}
