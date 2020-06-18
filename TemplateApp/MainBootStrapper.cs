using Autofac;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;
using TemplateApp.ViewModels;

namespace TemplateApp
{
    public class MainBootStrapper : BootstrapperBase
    {
        private IContainer container;

        protected override void Configure()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
            containerBuilder.RegisterType<WindowManager>().As<IWindowManager>().SingleInstance();

            containerBuilder.RegisterType<MainViewModel>().As<IMainViewModel>();
            containerBuilder.RegisterType<SubViewModel>().As<ISubViewModel>();

            container = containerBuilder.Build();
        }

        protected override void OnExit(object sender, EventArgs e)
        {
            container.Dispose();
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
                throw new ArgumentNullException(nameof(service));

            return container.Resolve(service);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.Resolve(typeof(IEnumerable<>).MakeGenericType(service)) as IEnumerable<object>;
        }

        protected override void BuildUp(object instance)
        {
            container.InjectProperties(instance);
        }

        protected override void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;

            MessageBox.Show(e.Exception.Message, "An error as occurred", MessageBoxButton.OK);
        }
    }
}
