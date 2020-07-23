using Caliburn.Micro;
using System.ComponentModel;

namespace TemplateApp.Settings
{
    internal interface ISettingsManager : INotifyPropertyChanged
    {
        bool UseDarkTheme { get; set; }
    }

    internal class SettingsManager : PropertyChangedBase, ISettingsManager
    {
        public bool UseDarkTheme
        {
            get => Settings.Default.UseDarkTheme;
            set
            {
                Settings.Default.UseDarkTheme = value;
                Settings.Default.Save();
                NotifyOfPropertyChange();
            }
        }
    }
}
