using Projectedu.API.Library.Helpers;
using Projectedu.API.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectedu.API.Library.DataAccess
{
    public class ExamData : IExamData
    {
        private ISqlDataAccess _dataAccess;

        public ExamData(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public List<ExamModel> GetUserExams(int userId)
        {
            return _dataAccess.LoadData<ExamModel, dynamic>("dbo.spExam_GetUserExams", new { CreatedById = userId });
        }

        public void CreateExam(ExamModel exam)
        {
            // add any other properties to be used by the store procedure
            _dataAccess.SaveData("spExam_Create", new { CreatedBy = exam.CreatedBy, Name = exam.Name, Description = exam.Description });
        }
    }
}
