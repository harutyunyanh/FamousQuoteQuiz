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

        [HttpGet("{userId}")]
        public UIResult<GetUserDetailsModel> GetUserDetails(int userId)
        {
            return UserManager.GetUserDetails(userId);
        }
        [HttpPatch]
        public UIResult<Page<GetUserListModel>> GetUserList(UITableSortingAndFilterModel sortingAndFilterModel)
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
            return UserManager.DeleteUser(userId);
        }
        [HttpPut("{userId}")]
        public UIResult<string> EditUser(int userId,EditUserModel model)
        {
            return UserManager.EditUser(userId,model);
        }
    }
}
