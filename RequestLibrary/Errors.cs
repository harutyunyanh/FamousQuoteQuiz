using CommonLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RequestLibrary
{
    public static class Errors
    {
        public static Error RequestLibrary_Request_Make_Exception => new Error("RL-001", "UNHANDELED CASE");
        public static Error RequestLibrary_Request_Make_InvalidRequest => new Error("RL-002", "Invalid Request");
        public static Error RequestLibrary_Request_Make_NotSuccessStatusCode => new Error("RL-002", "Not Success Status Code");
        public static Error RequestLibrary_Request_Make_JsonToObjectParseFailure => new Error("RL-003", "Json To Object Parse Failure");
    }
}
