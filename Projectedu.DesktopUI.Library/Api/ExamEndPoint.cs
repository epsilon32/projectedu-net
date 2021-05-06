using Projectedu.DesktopUI.Library.Helpers;
using Projectedu.DesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Projectedu.DesktopUI.Library.Api
{
    public class ExamEndPoint : IExamEndPoint
    {

        private IApiHelper _apiHelper;

        public ExamEndPoint(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<ExamModel>> GetUserExams()
        {
            using (var response = await _apiHelper.ApiClient.GetAsync("Exam"))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<ExamModel>>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
