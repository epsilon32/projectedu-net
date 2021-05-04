using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Projectedu.DesktopUI.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Projectedu.DesktopUI.Helpers
{
    /// <summary>
    /// For now, use this common class to access the API from WPF
    /// May want to move this to another project?
    /// </summary>
    public class ApiHelper : IApiHelper
    {
        private HttpClient _apiClient;

        private IConfiguration _configuration;

        public ApiHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            InitializeClient();
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

            using (var response = await _apiClient.PostAsync("Authentication/login", content))
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

    }
}
