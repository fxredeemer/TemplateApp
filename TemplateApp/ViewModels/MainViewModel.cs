using Stylet;
using System.Collections.Generic;

namespace TemplateApp.ViewModels
{
    internal interface IMainViewModel
    {
        string SubItemTitle { get; }
        int Number { get; }

        void Previous();
        void Next();
    }

    internal class MainViewModel : Conductor<IPageViewModel>, IMainViewModel
    {
        private readonly IList<IPageViewModel> pages = new List<IPageViewModel>();

        public MainViewModel(
            IPage1ViewModel firstPage,
            IPage2ViewModel secondPage)
        {
            pages.Add(firstPage);
            pages.Add(secondPage);

            ActivateItem(pages[0]);
        }

        public string RandomText { get; set; }

        public int Number => 1337;

        public string SubItemTitle => ActiveItem.Title;

        public void Next()
        {
            var pageIndex = pages.IndexOf(ActiveItem);
            pageIndex++;
            pageIndex = pageIndex > pages.Count - 1 ? pages.Count - 1 : pageIndex;

            ActivateItem(pages[pageIndex]);
            NotifyOfPropertyChange(nameof(SubItemTitle));
        }

        public void Previous()
        {
            var pageIndex = pages.IndexOf(ActiveItem);
            pageIndex--;
            pageIndex = pageIndex < 0 ? 0 : pageIndex;

            ActivateItem(pages[pageIndex]);
        }
    }
}
