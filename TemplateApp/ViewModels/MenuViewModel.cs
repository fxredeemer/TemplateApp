using Caliburn.Micro;
using TemplateApp.Settings;

namespace TemplateApp.ViewModels
{
    internal interface IMenuViewModel
    {
        bool DarkTheme { get; set; }
    }

    class MenuViewModel : PropertyChangedBase, IMenuViewModel
    {
        private readonly ISettingsManager settingsManager;
        private readonly IApplicationManager applicationManager;

        public MenuViewModel(
            ISettingsManager settingsManager,
            IApplicationManager applicationManager)
        {
            this.settingsManager = settingsManager;
            this.applicationManager = applicationManager;
            settingsManager.PropertyChanged += (_, __) => Refresh();
        }

        public bool DarkTheme
        {
            get => settingsManager.UseDarkTheme;
            set => settingsManager.UseDarkTheme = value;
        }

        public void Exit()
        {
            applicationManager.Close();
        }
    }
}
