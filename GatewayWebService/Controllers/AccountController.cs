using CommonLibrary.DBModels;
using CommonLibrary.Models;
using GatewayWebService.Helper;
using GatewayWebService.Manager;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayWebService.Controllers
{
    [Route("[controller]")]
    public class AccountController : BaseController
    {
        [HttpPatch("client/login")]
        public UIResult<LoginResponse> ClientLogin(LoginModel loginmodel)
        {
            return LoginSignManager.ClientLogin(loginmodel);
        }

        [HttpPost("client/signup")]
        public UIResult<LoginResponse> ClientSignUp(SignModel signmodel)
        {
            return LoginSignManager.ClientSign(signmodel);
        }
        [HttpPatch("user/login")]
        public UIResult<LoginResponse> UserLogin(LoginModel loginmodel)
        {
            return LoginSignManager.UserLogin(loginmodel);
        }
    }

}
