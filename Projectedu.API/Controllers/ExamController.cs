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
    [JwtAuthorize]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private IExamData _examData;

        public ExamController(IExamData examData)
        {
            _examData = examData;
        }

        [HttpGet]
        public List<ExamModel> GetUserExams()
        {
            var userModel = Request.HttpContext.Items["User"] as UserModel;
            return _examData.GetUserExams(userModel.Id);
        }

        [HttpPost]
        public void CreateExam(ExamModel exam)
        {
            _examData.CreateExam(exam);
        }

    }
}
