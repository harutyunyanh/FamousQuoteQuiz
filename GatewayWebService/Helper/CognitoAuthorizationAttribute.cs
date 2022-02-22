using GatewayWebService.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayWebService.Helper
{
    public class CognitoAuthorizationAttribute : ActionFilterAttribute, IActionFilter
    {
        public AuthorizationRoleEnum Role { get; set; }

        public CognitoAuthorizationAttribute() { }


        // TODO Add logs
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string token = context.HttpContext.Request.Headers["X-Authorization"];

            if (Role == AuthorizationRoleEnum.User)
            {
                int userId;
                bool keyExists = Tokens.userTokenList.TryGetValue(token, out userId);

                if (keyExists)
                {
                    ((IBaseController)context.Controller).ClientID = userId;
                    base.OnActionExecuting(context);
                }
                else
                {
                    context.Result = new UnauthorizedObjectResult("Access denied");
                }
            }
            else
            {
                int clientId;
                bool keyExists = Tokens.clientTokenList.TryGetValue(token, out clientId);

                if (keyExists)
                {
                    ((IBaseController)context.Controller).ClientID = clientId;
                    base.OnActionExecuting(context);
                }
                else
                {
                    context.Result = new UnauthorizedObjectResult("Access denied");
                }
            }
        }
    }
}
