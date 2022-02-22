using CommonLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayWebService.Model
{
    public static class Errors
    {
        public static Error To_Do => new Error("ToDO-01", "ToDo Faild");

        public static Error GetUserList_Error => new Error("GU-01", "GatewayWebService_GetUserList Faild");

    }
}
