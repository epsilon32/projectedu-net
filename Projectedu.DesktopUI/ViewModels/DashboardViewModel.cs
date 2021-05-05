using Caliburn.Micro;
using ProjectEdu.DesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectedu.DesktopUI.ViewModels
{
    public class DashboardViewModel: Screen
    {

        private ILoggedInUserModel _loggedInUser;

        public DashboardViewModel(ILoggedInUserModel loggedInUser)
        {
            _loggedInUser = loggedInUser;
        }

        public string FirstName
        {
            get { return _loggedInUser.FirstName; }
        }

        public string LastName
        {
            get { return _loggedInUser.LastName; }
        }

    }
}
