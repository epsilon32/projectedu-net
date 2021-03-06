using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Projectedu.API.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projectedu.API.Helpers
{
    /// <summary>
    /// Custom autorization attribute, use this attribute to secure a class or 
    /// method with JWT authorization
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class JwtAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.Items["User"] as UserModel;
            if (user == null)
            {
                // not logged in (401 error)
                context.Result = new JsonResult(new 
                    { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
            // TODO add roles checking? if needed, add role param to attribute, then 
            // check the role based on httpcontext, then return unautorized
        }
    }
}
