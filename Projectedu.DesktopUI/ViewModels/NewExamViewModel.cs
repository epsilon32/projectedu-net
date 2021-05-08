using Caliburn.Micro;
using Projectedu.DesktopUI.Library.Api;
using Projectedu.DesktopUI.Library.Models;
using ProjectEdu.DesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Projectedu.DesktopUI.ViewModels
{
    public class NewExamViewModel: Screen
    {
        private ILoggedInUserModel _loggedInUser;
        private IExamEndPoint _examEndPoint;
        private ExamModel _newExam;
        public ExamModel NewExam
        {
            get
            {
                return _newExam;
            }
            set
            {
                _newExam = value;
                NotifyOfPropertyChange(() => NewExam);
            }
        }

        public NewExamViewModel(ILoggedInUserModel loggedInUser, IExamEndPoint examEndPoint)
        {
            _examEndPoint = examEndPoint;
            _loggedInUser = loggedInUser;
            NewExam = new ExamModel { CreatedBy = _loggedInUser.Id };
        }

        public async Task Save()
        {
            try
            {
                await _examEndPoint.CreateExam(NewExam);
                MessageBox.Show($"{NewExam.Name} was added.");
                NewExam = new ExamModel { CreatedBy = _loggedInUser.Id };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured. {ex.Message}");
            }        
        }
    }
}
