namespace TemplateApp.ViewModels
{
    public interface IMainViewModel
    {
        string RandomText { get; set; }
        int Number { get; }
        ISubViewModel SubContent { get; }
    }

    public class MainViewModel : IMainViewModel
    {
        public MainViewModel(ISubViewModel subViewModel)
        {
            SubContent = subViewModel;
        }

        public string RandomText { get; set; }

        public int Number => 1337;

        public ISubViewModel SubContent { get; }
    }
}
