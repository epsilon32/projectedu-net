using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projectedu.API.Helpers;
using Projectedu.API.Library.DataAccess;
using Projectedu.API.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projectedu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [JwtAuthorize]
    public class UserController : ControllerBase
    {
        private readonly IUserData _userData;

        public UserController(IUserData userData)
        {
            _userData = userData;
        }

        [HttpGet]
        public UserModel GetById()
        {
            var userModel = Request.HttpContext.Items["User"] as UserModel;
            return _userData.GetById(userModel.Id);
        }


    }
}
