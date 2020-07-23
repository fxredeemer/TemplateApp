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

        public MenuViewModel(ISettingsManager settingsManager)
        {
            this.settingsManager = settingsManager;

            settingsManager.PropertyChanged += (_, __) => Refresh();
        }

        public bool DarkTheme
        {
            get => settingsManager.UseDarkTheme;
            set => settingsManager.UseDarkTheme = value;
        }
    }
}
