using CommonLibrary.DBModels;
using CommonLibrary.Models;
using GatewayWebService.Helper;
using GatewayWebService.Manager;
using GatewayWebService.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GatewayWebService.Controllers
{
    [Route("[controller]")]
   // [CognitoAuthorization(Role = AuthorizationRoleEnum.User)]
    public class QuizController : BaseController
    {
        [HttpGet()]
        public UIResult<List<GetQuizModel>> GetUserDetails()
        {
            return new UIResult<List<GetQuizModel>>() { Status = UIResultStatus.Success, Data = new List<GetQuizModel>() { new GetQuizModel(), new GetQuizModel(), new GetQuizModel() } };
        }
    }
}
