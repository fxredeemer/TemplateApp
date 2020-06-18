namespace TemplateApp.ViewModels
{
    public interface ISubViewModel
    {
        public string Data { get; }
    }

    public class SubViewModel : ISubViewModel
    {
        public string Data => "Sub Item Property";
    }
}
