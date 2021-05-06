using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ProjectEdu.DesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Projectedu.DesktopUI.Library.Helpers
{
    /// <summary>
    /// For now, use this common class to access the API from WPF
    /// May want to move this to another project?
    /// </summary>
    public class ApiHelper : IApiHelper
    {
        private HttpClient _apiClient;

        private IConfiguration _configuration;
        private ILoggedInUserModel _loggedInUser;

        public ApiHelper(IConfiguration configuration, ILoggedInUserModel loggedInUser)
        {
            _configuration = configuration;
            _loggedInUser = loggedInUser;
            InitializeClient();
        }

        public HttpClient ApiClient
        {
            get { return _apiClient; }
        }

        private void InitializeClient()
        {
            _apiClient = new HttpClient();
            // set base api address from appsettings
            _apiClient.BaseAddress = new Uri(_configuration.GetValue<string>("api"));
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            // only json accepted (for now)
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<AuthenticatedUser> Authenticate(string username, string password)
        {
            var content = new StringContent(JsonConvert.SerializeObject(new { username = username, password = password }),
                Encoding.UTF8, "application/json");

            using (var response = await _apiClient.PostAsync("Token", content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<AuthenticatedUser>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<LoggedInUserModel> GetLoggedInUserInfo(string token)
        {
            _apiClient.DefaultRequestHeaders.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _apiClient.DefaultRequestHeaders.Add("Authorization", $"Bearer { token }");

            using (var response = await _apiClient.GetAsync("User"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<LoggedInUserModel>();
                    _loggedInUser.Id = result.Id;
                    _loggedInUser.FirstName = result.FirstName;
                    _loggedInUser.LastName = result.LastName;
                    _loggedInUser.Username = result.Username;
                    _loggedInUser.Token = token;
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
