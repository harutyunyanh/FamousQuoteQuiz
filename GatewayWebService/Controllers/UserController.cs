using CommonLibrary.DBModels;
using CommonLibrary.Models;
using GatewayWebService.Helper;
using GatewayWebService.Manager;
using GatewayWebService.Model;
using Microsoft.AspNetCore.Mvc;


namespace GatewayWebService.Controllers
{
    [Route("[controller]")]
    [CognitoAuthorization(Role = AuthorizationRoleEnum.User)]
    public class UserController : BaseController
    {

        [HttpPatch]
        public UIResult<Page<GetUserModel>> GetUserList(UITableSortingAndFilterModel sortingAndFilterModel)
        {
            return UserManager.GetUserList(sortingAndFilterModel);
        }
    }
}
