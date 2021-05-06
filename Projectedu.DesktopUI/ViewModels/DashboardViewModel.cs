using Caliburn.Micro;
using Projectedu.DesktopUI.Library.Api;
using Projectedu.DesktopUI.Library.Models;
using ProjectEdu.DesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectedu.DesktopUI.ViewModels
{
    public class DashboardViewModel: Screen
    {
        private ILoggedInUserModel _loggedInUser;
        private IExamEndPoint _examEndPoint;

        public DashboardViewModel(ILoggedInUserModel loggedInUser, IExamEndPoint examEndPoint)
        {
            _loggedInUser = loggedInUser;
            _examEndPoint = examEndPoint;
        }

        public string FirstName
        {
            get { return _loggedInUser.FirstName; }
        }

        public string LastName
        {
            get { return _loggedInUser.LastName; }
        }

        private BindingList<ExamModel> _userExams;
        public BindingList<ExamModel> UserExams
        {
            get
            {
                return _userExams;
            }
            set
            {
                _userExams = value;
                NotifyOfPropertyChange(() => UserExams);
            }
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadUserExams();
        }

        public async Task LoadUserExams()
        {
            var examList = await _examEndPoint.GetUserExams();
            UserExams = new BindingList<ExamModel>(examList);
        }

    }
}
