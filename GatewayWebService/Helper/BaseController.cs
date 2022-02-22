using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayWebService.Helper
{
    [ApiController]
    public class BaseController : ControllerBase, IBaseController
    {
        public BaseController()
        {
        }

        public long UserId { get; set; }
        public long ClientID { get; set; }
        public string APIToken { get; set; }
    }
}
