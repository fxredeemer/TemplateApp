using AdonisUI;
using System.ComponentModel;
using System.Windows;

namespace TemplateApp.Settings
{
    internal interface IApplicationManager
    {
        void Close();
        void Initialize();
    }

    class ApplicationManager : IApplicationManager
    {
        private readonly ISettingsManager settingsManager;

        public ApplicationManager(ISettingsManager settingsManager)
        {
            this.settingsManager = settingsManager;

            settingsManager.PropertyChanged += SettingsManager_PropertyChanged;
        }

        private void SettingsManager_PropertyChanged(object _, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(settingsManager.UseDarkTheme))
            {
                SetThemeFromSettings();
            }
        }

        public void Initialize()
        {
            SetThemeFromSettings();
        }

        private void SetThemeFromSettings()
        {
            var useDarkTheme = settingsManager.UseDarkTheme;

            var themeToUse = useDarkTheme ? ResourceLocator.DarkColorScheme : ResourceLocator.LightColorScheme;
            ResourceLocator.SetColorScheme(Application.Current.Resources, themeToUse);
        }

        public void Close()
        {
            Application.Current.Shutdown();
        }
    }
}
