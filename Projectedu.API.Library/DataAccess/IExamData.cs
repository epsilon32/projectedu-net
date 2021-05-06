using Projectedu.API.Library.Models;
using System.Collections.Generic;

namespace Projectedu.API.Library.DataAccess
{
    public interface IExamData
    {
        List<ExamModel> GetUserExams(int userId);
    }
}