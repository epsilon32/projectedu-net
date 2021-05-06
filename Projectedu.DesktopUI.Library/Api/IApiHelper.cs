using ProjectEdu.DesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Projectedu.DesktopUI.Library.Helpers
{
    public interface IApiHelper
    {
        HttpClient ApiClient { get; }
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task<LoggedInUserModel> GetLoggedInUserInfo(string token);
    }
}
