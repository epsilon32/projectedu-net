using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using Projectedu.DesktopUI.EventModels;

namespace Projectedu.DesktopUI.ViewModels
{
    /// <summary>
    /// Root viewmodel for whole screen 
    /// For now, only allows one form at a time
    /// </summary>
    public class ShellViewModel: Conductor<object>, IHandle<LogOnEvent>
    {
        private DashboardViewModel _dashboardViewModel;
        private SimpleContainer _container;
        private IEventAggregator _events;

        private WindowState _curWindowState;
        public WindowState CurWindowState
        {
            get
            {
                return _curWindowState;
            }
            set
            {
                _curWindowState = value;
                NotifyOfPropertyChange(() => CurWindowState);
            }
        }

        public ShellViewModel(DashboardViewModel dashboardViewModel,
            SimpleContainer container, IEventAggregator events)
        {
            _dashboardViewModel = dashboardViewModel;
            _container = container;
            _events = events;
            _events.SubscribeOnPublishedThread(this);
            ActivateItemAsync(_container.GetInstance<LoginViewModel>());
            CurWindowState = WindowState.Normal;
        }

        /// <summary>
        /// Handles screen change event (login event)
        /// Use event aggregator to trigger this event
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {
            CurWindowState = WindowState.Maximized;
            return ActivateItemAsync(_dashboardViewModel);
        }
    }
}
