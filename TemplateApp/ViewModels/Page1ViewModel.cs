using Caliburn.Micro;

namespace TemplateApp.ViewModels
{
    internal interface IPage1ViewModel : IPageViewModel
    {
        string SubItemData { get; }
        string RandomText { get; set; }
    }

    internal class Page1ViewModel : PropertyChangedBase, IPage1ViewModel
    {
        private string randomText;

        public string Title => "Page1";
        
        public string SubItemData => $"Page 1 Content : {RandomText}";

        public string RandomText
        {
            get => randomText;
            set
            {
                randomText = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(nameof(SubItemData));
            }
        }
    }
}
