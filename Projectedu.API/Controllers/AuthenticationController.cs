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
    public class AuthenticationController : Controller
    {
        private readonly AppSettings _appSettings;
        private IUserService _userService;

        public AuthenticationController(IOptions<AppSettings> appSettings, IUserService userService)
        {
            _appSettings = appSettings.Value;
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(AuthenticateRequest model)
        {
            var result = _userService.Authenticate(model);

            if (result == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(result);
        }
    }
}
