namespace TemplateApp.ViewModels
{
    internal interface IPage2ViewModel : IPageViewModel
    {

    }

    internal class Page2ViewModel : IPage2ViewModel
    {
        public string Title => "Page2";
        public string Data => "Page 2 Content";
    }
}
