using Projectedu.API.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projectedu.API.Models
{
    /// <summary>
    /// Reponse to an Authenticate Request (return of a login request)
    /// </summary>
    public class TokenResponse
    {
        public int Id { get; set; }
        public string Token { get; set; }

        public TokenResponse(UserModel user, string token)
        {
            Id = user.Id;
            Token = token;
        }
    }
}
