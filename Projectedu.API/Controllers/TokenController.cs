using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Projectedu.API.Models;
using Projectedu.API.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Projectedu.API.Library.DataAccess;
using Microsoft.Extensions.Options;
using Projectedu.API.Library.Models;
using Projectedu.API.Services;

namespace Projectedu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        private IUserService _userService;

        public TokenController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult GenerateToken(TokenRequest model)
        {
            var result = _userService.Authenticate(model);

            if (result == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(result);
        }
    }
}
