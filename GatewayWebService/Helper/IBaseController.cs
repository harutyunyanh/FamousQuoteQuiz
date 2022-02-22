using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayWebService.Helper
{
    public interface IBaseController
    {
        public long UserId { get; set; }
        public long ClientID { get; set; }
        public string APIToken { get; set; }

    }
}
