using Caliburn.Micro;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplateApp.ViewModels
{
    internal interface IMainViewModel
    {
        string SubItemTitle { get; }
        int Number { get; }
        IMenuViewModel Menu { get; }

        Task Previous();
        Task Next();
    }

    internal class MainViewModel : Conductor<IPageViewModel>, IMainViewModel
    {
        private readonly IList<IPageViewModel> pages = new List<IPageViewModel>();

        public MainViewModel(
            IMenuViewModel menuViewModel,
            IPage1ViewModel firstPage,
            IPage2ViewModel secondPage)
        {
            Menu = menuViewModel;
            pages.Add(firstPage);
            pages.Add(secondPage);

            ActivateItemAsync(pages.First());
        }

        public string RandomText { get; set; }

        public int Number => 1337;

        public string SubItemTitle => ActiveItem.Title;

        public IMenuViewModel Menu { get; }

        public async Task Next()
        {
            var pageIndex = pages.IndexOf(ActiveItem);
            pageIndex++;
            pageIndex = pageIndex > pages.Count - 1 ? pages.Count - 1 : pageIndex;

            await ActivateItemAsync(pages[pageIndex]);
            NotifyOfPropertyChange(nameof(SubItemTitle));
        }

        public async Task Previous()
        {
            var pageIndex = pages.IndexOf(ActiveItem);
            pageIndex--;
            pageIndex = pageIndex < 0 ? 0 : pageIndex;

            await ActivateItemAsync(pages[pageIndex]);
        }
    }
}
