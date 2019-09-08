

namespace AWS_Wpf_Project.Interface
{
    public interface IMessagable
    {
        void ShowErrorMessage(string title, string text);
        void ShowInfoMessage(string title, string text);
    }
}
