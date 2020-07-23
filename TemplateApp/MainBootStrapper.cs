using Caliburn.Micro;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;
using TemplateApp.Settings;
using TemplateApp.ViewModels;

namespace TemplateApp
{
    internal class MainBootStrapper : BootstrapperBase
    {
        private IServiceProvider serviceProvider;

        protected override void Configure()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IEventAggregator, EventAggregator>();
            serviceCollection.AddSingleton<IWindowManager, WindowManager>();

            serviceCollection.AddScoped<ISettingsManager, SettingsManager>();

            serviceCollection.AddTransient<IMainViewModel, MainViewModel>();
            serviceCollection.AddTransient<IMenuViewModel, MenuViewModel>();
            serviceCollection.AddTransient<IPage1ViewModel, Page1ViewModel>();
            serviceCollection.AddTransient<IPage2ViewModel, Page2ViewModel>();

            serviceProvider = serviceCollection.BuildServiceProvider();
        }

        protected override void OnExit(object sender, EventArgs e)
        {
            base.OnExit(sender, e);
        }

        public MainBootStrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<IMainViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            return serviceProvider.GetService(service);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return serviceProvider.GetServices(service);
        }

        protected override void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;

            MessageBox.Show(e.Exception.Message, "An error as occurred", MessageBoxButton.OK);
        }
    }
}
