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

        [HttpPost]
        public UIResult<string> AddUser(AddUserModel model)
        {
            return UserManager.AddUser(model);
        }

        [HttpDelete("{userId}")]
        public UIResult<string> DeleteUser(int userId)
        {
            return null;
            //return UserManager.GetUserList(sortingAndFilterModel);
        }
        [HttpPut("{userId}")]
        public UIResult<string> EditUser(int userId)
        {
            return null;
            //return UserManager.GetUserList(sortingAndFilterModel);
        }
    }
}
