using Projectedu.DesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projectedu.DesktopUI.Library.Api
{
    public interface IExamEndPoint
    {
        Task<List<ExamModel>> GetUserExams();
    }
}