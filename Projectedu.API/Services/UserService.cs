using Microsoft.Extensions.Options;
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
using Projectedu.API.Library.Models;

namespace Projectedu.API.Services
{
    public interface IUserService
    {
        TokenResponse Authenticate(TokenRequest model);
        UserModel GetById(int id);
    }

    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private IUserData _userData;

        public UserService(IOptions<AppSettings> appSettings, IUserData userData)
        {
            _appSettings = appSettings.Value;
            _userData = userData;
        }

        public TokenResponse Authenticate(TokenRequest model)
        {
            var user = _userData.GetUserByNamePass(model.Username, model.Password)?.FirstOrDefault();

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new TokenResponse(user, token);
        }

        public UserModel GetById(int id)
        {
            return _userData.GetById(id);
        }

        /// <summary>
        /// Generates JWT for the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string generateJwtToken(UserModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7), // valid for 7 days
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
