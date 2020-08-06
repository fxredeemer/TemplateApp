using Stylet;
using StyletIoC;
using System;
using TemplateApp.ViewModels;

namespace TemplateApp
{
    internal class MainBootStrapper : Bootstrapper<MainViewModel>
    {
        protected override void ConfigureIoC(IStyletIoCBuilder builder)
        {
            builder.Bind<IEventAggregator>().To<EventAggregator>();
            builder.Bind<IWindowManager>().To<WindowManager>();

            builder.Bind<IMainViewModel>().To<MainViewModel>();
            builder.Bind<IPage1ViewModel>().To<Page1ViewModel>();
            builder.Bind<IPage2ViewModel>().To<Page2ViewModel>();
        }
    }
}
