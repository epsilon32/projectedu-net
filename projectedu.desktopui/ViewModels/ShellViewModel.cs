using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Projectedu.DesktopUI.ViewModels
{
    /// <summary>
    /// Root viewmodel for whole screen 
    /// For now, only allows one form at a time
    /// </summary>
    public class ShellViewModel: Conductor<object>
    {

        private LoginViewModel _loginViewModel;

        public ShellViewModel(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;
            ActivateItemAsync(_loginViewModel);
        }


    }
}
