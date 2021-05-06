using Caliburn.Micro;
using Microsoft.Extensions.Configuration;
using Projectedu.DesktopUI.Helpers;
using Projectedu.DesktopUI.Library.Api;
using Projectedu.DesktopUI.Library.Helpers;
using Projectedu.DesktopUI.ViewModels;
using ProjectEdu.DesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Projectedu.DesktopUI
{
    public class Bootstrapper: BootstrapperBase
    {

        private SimpleContainer _container = new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();

            ConventionManager.AddElementConvention<PasswordBox>(
                PasswordBoxHelper.BoundPasswordProperty,
                "Password",
                "PasswordChanged");
        }

        private IConfiguration AddConfiguration()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
#if DEBUG
            builder.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
#else
            builder.AddJsonFile("appsettings.Production.json", optional: true, reloadOnChange: true);
#endif
            return builder.Build();
        }

        protected override void Configure()
        {
            // setups dependency injection instances
            _container.Instance(_container)
                .PerRequest<IExamEndPoint, ExamEndPoint>();

            // all the singletons
            _container.Singleton<IWindowManager, WindowManager>()
                        .Singleton<IEventAggregator, EventAggregator>()
                        .Singleton<ILoggedInUserModel, LoggedInUserModel>()
                        .Singleton<IApiHelper, ApiHelper>();
            
            // setup appsettings.json
            _container.RegisterInstance(typeof(IConfiguration), "IConfiguration", AddConfiguration());

            // all the view models
            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            // launches ShellViewModel as default view model
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

    }
}
