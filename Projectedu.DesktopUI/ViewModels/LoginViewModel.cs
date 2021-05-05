using Caliburn.Micro;
using Projectedu.DesktopUI.EventModels;
using Projectedu.DesktopUI.Helpers;
using Projectedu.DesktopUI.Library.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectedu.DesktopUI.ViewModels
{
    public class LoginViewModel: Screen
    {
        private IApiHelper _apiHelper;
        private IEventAggregator _events;

        public LoginViewModel(IApiHelper apiHelper, IEventAggregator events)
        {
            _apiHelper = apiHelper;
            _events = events;
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                NotifyOfPropertyChange(() => Username);
                NotifyOfPropertyChange(() => CanLogin); //  refresh CanLogin on username change
            }
        }


        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogin); //  refresh CanLogin on password change
            }
        }

        public bool IsErrorVisible
        {
            get { return ErrorMessage?.Length > 0 ; }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set 
            { 
                _errorMessage = value;
                NotifyOfPropertyChange(() => IsErrorVisible);
                NotifyOfPropertyChange(() => ErrorMessage);
            }
        }

        public bool CanLogin
        {
            get
            {
                return Username?.Length > 0 && Password?.Length > 0;
            }
        }

        // methods

        public async Task Login()
        {
            try
            {
                ErrorMessage = string.Empty;
                var result = await _apiHelper.Authenticate(Username, Password);
                await _apiHelper.GetLoggedInUserInfo(result.Token);
                await _events.PublishOnUIThreadAsync(new LogOnEvent());
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
